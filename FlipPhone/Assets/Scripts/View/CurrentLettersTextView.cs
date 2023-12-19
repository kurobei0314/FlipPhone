using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentLettersTextView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    
    public void UpdateCurrentLettersText(string currentLetters)
    {
        _text.text = currentLetters;
    }
}
