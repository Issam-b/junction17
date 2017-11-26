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
    public GameObject floor1, floor2;
    Vector3 F1Initial, F2Initial;

    KeywordRecognizer _keywordRecognizer = null;
    Dictionary<string, Action> _keywords = new Dictionary<string, Action>();


    private string _lastCommand = null;
    private float _lastNumber = 0;
    //private AudioClip _audioClip;

    AnimationController animController = new AnimationController();



    public void ShowFurn()
    {

    }
		

    void Start()
    {

        F1Initial = floor1.transform.position;
        F2Initial = transform.position;

        _keywords.Add("Zoom In 2", () =>
        {
            animController.ZoomFloor2();
        });

        _keywords.Add("Zoom In 1", () =>
        {
            animController.ZoomFloor1();
        });

        _keywords.Add("Turn right", () =>
        {
            animController.ShiftRight();
        });

        _keywords.Add("Turn right", () =>
        {
            animController.ShiftLeft();
        });

        _keywords.Add("Reset", () =>
        {
            animController.ShiftRight();
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

}
