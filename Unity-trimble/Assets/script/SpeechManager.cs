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
    public static int activeFloor = 0;

    KeywordRecognizer _keywordRecognizer = null;
    Dictionary<string, Action> _keywords = new Dictionary<string, Action>();


    private string _lastCommand = null;
    private float _lastNumber = 0;
    //private AudioClip _audioClip;

    AnimationController animController = new AnimationController();


    public void ShiftRight()
    {
        
    }

    public void ShiftLeft()
    {
        
    }

    public void ZoomFloor1()
    {
        

    }

    public void ZoomFloor2()
    {
        

    }

    void Start()
    {

        F1Initial = floor1.transform.position;
        F2Initial = transform.position;

        _keywords.Add("Zoom In Two", () =>
        {
            activeFloor = 2;
            AnimationController.activeFloor = 2;
            floor2.SetActive(true);
            floor1.SetActive(false);
            floor2.transform.DOMove(new Vector3(6f, -2f, 1.5f), 2);
            floor2.transform.DOScale(new Vector3(20, 20, 20), 2);
        });

        _keywords.Add("Zoom In One", () =>
        {
            activeFloor = 1;
            AnimationController.activeFloor = 1;
            floor1.SetActive(true);
            floor2.SetActive(false);
            floor1.transform.DOMove(new Vector3(3.35f, -1.93f, 0.5f), 2);
            floor1.transform.DOScale(new Vector3(20, 20, 20), 2);
        });

        //_keywords.Add("Turn Right", () =>
        //{
        //    activeFloor = 0;
        //    AnimationController.activeFloor = 0;
        //    floor1.SetActive(true);
        //    floor2.SetActive(true);
        //    floor1.transform.position = F1Initial;
        //    floor2.transform.position = F2Initial;
        //    floor1.transform.DOScale(new Vector3(1, 1, 1), 1);
        //    floor2.transform.DOScale(new Vector3(1, 1, 1), 1);
        //    floor2.transform.DOMove(new Vector3(1.5f, F2Initial.y, 1.5f), 2);
        //});

        _keywords.Add("Turn Left", () =>
        {
            activeFloor = 0;
            AnimationController.activeFloor = 0;
            floor1.SetActive(true);
            floor2.SetActive(true);
            floor1.transform.position = F1Initial;
            floor2.transform.position = F2Initial;
            floor1.transform.DOScale(new Vector3(1, 1, 1), 1);
            floor2.transform.DOScale(new Vector3(1, 1, 1), 1);
            floor2.transform.DOMove(new Vector3(F2Initial.x, F2Initial.y, 1.5f), 2);
        });

        _keywords.Add("Reset", () =>
        {
            activeFloor = 0;
            AnimationController.activeFloor = 0;
            floor1.SetActive(true);
            floor2.SetActive(true);
            floor1.transform.position = F1Initial;
            floor2.transform.position = F2Initial;
            floor1.transform.DOScale(new Vector3(1, 1, 1), 1);
            floor2.transform.DOScale(new Vector3(1, 1, 1), 1);
            floor2.transform.DOMove(new Vector3(1.5f, F2Initial.y, 1.5f), 2);
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
