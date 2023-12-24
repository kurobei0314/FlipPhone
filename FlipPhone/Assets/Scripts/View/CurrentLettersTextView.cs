using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UniRx;

public class CurrentLettersTextView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void Initialize()
    {
        _text.text = "";
    }
    
    public void UpdateCurrentLettersText(string currentLetters)
    {
        _text.text = currentLetters;
    }
}
