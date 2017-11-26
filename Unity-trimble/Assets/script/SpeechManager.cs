using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.UI;

public class SpeechManager : MonoBehaviour
{

    KeywordRecognizer _keywordRecognizer = null;
    Dictionary<string, Action> _keywords = new Dictionary<string, Action>();


    private string _lastCommand = null;
    private float _lastNumber = 0;
    private AudioClip _audioClip;



  

    public void ZoomIn()
    {

    }

    public void ShowFurn()
    {

    }
		

    void Start()
    {

        _keywords.Add("Zoom In", () =>
        {
				ZoomIn();
        });

		_keywords.Add("Show forniture", () =>
        {
				ShowFurn();
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
