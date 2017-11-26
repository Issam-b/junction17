using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.UI;
using DG.Tweening;


public class SpeechManager : MonoBehaviour
{
    public GameObject floor1;
    Vector3 F1Initial, F2Initial;

    KeywordRecognizer _keywordRecognizer = null;
    Dictionary<string, Action> _keywords = new Dictionary<string, Action>();


    private string _lastCommand = null;
    private float _lastNumber = 0;
    //private AudioClip _audioClip;



    public void ShowFurn()
    {

    }
		

    void Start()
    {

        F1Initial = floor1.transform.position;
        F2Initial = transform.position;

        _keywords.Add("Zoom In", () =>
        {
            ZoomFloor2();
        });

		_keywords.Add("Turn right", () =>
        {
            ShiftRight();
        });

        _keywords.Add("Turn right", () =>
        {
            ShiftLeft();
        });



        _keywordRecognizer = new KeywordRecognizer(_keywords.Keys.ToArray());

        _keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        _keywordRecognizer.Start();

    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        Action keywordAction;
        if (_keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }

    public void ShiftRight()
    {
        floor1.SetActive(true);
        floor1.transform.position = F1Initial;
        transform.position = F2Initial;
        transform.DOScale(new Vector3(1, 1, 1), 1);
        transform.DOMove(new Vector3(1.5f, 0, 1.5f), 2);
    }

    public void ShiftLeft()
    {
        floor1.SetActive(true);
        floor1.transform.position = F1Initial;
        transform.position = F2Initial;
        transform.DOScale(new Vector3(1, 1, 1), 1);
        transform.DOMove(new Vector3(0, 0, 1.5f), 2);
    }

    public void ZoomFloor2()
    {
        floor1.SetActive(false);
        transform.DOMove(new Vector3(6f, -2f, 1.5f), 2);
        transform.DOScale(new Vector3(25, 25, 25), 2);

    }

}
