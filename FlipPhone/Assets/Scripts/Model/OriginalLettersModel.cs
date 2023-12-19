using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginalLettersModel : MonoBehaviour
{
    // TODO: 選択肢を選んで動かすときの初期化でtextも動的に変化するようにする
    private string _originalLetters = "おはよう";

    public void SetOriginalLettersModel(string letters)
    {
        _originalLetters = letters;
    }

    public bool IsSameCurrentLetters(string currentLetters) => _originalLetters == currentLetters;
    
}
