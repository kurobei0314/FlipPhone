using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OriginalLettersTextView : MonoBehaviour
{
    // TODO: 選択肢を選んで動かすときの初期化でtextも動的に変化するようにする
    [SerializeField] private TextMeshProUGUI _text;

    public void Initialize(string text)
    {
        _text.text = text;
    }
}
