using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UniRx;

public class SelectionButtonView : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _text;

    private Subject<string> onClickItemSubject = new Subject<string>();
    public IObservable<string> OnClickItemObservable => onClickItemSubject;

    public void Initialize(string text)
    {
        _text.text = text;
    }

    public void OnClick()
    {
        onClickItemSubject.OnNext(_text.text);
    }
}
