using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class OriginalLettersModel : MonoBehaviour
{
    // TODO: 選択肢を選んで動かすときの初期化でtextも動的に変化するようにする
    private ReactiveProperty<string> _originalLetters = new ReactiveProperty<string>();
    public ReactiveProperty<string> OriginalLetters => _originalLetters;

    public void SetOriginalLettersModel(string letters)
    {
        _originalLetters.Value = letters;
    }

    public bool IsSameCurrentLetters(string currentLetters) => _originalLetters.Value == currentLetters;
    
}
