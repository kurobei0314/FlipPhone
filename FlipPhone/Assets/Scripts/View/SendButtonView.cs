using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

public class SendButtonView : MonoBehaviour
{
    [SerializeField] private Button _button;

    private Subject<Unit> onClickSendButtonSubject = new Subject<Unit>();
    public IObservable<Unit> OnClickSendButtonObservable => onClickSendButtonSubject;

    public void Start()
    {
        _button.interactable = false;
    }

    public void UpdateInteractable(bool isSameLetters)
    {
        _button.interactable = isSameLetters;
    }

    public void OnClick()
    {
        onClickSendButtonSubject.OnNext(Unit.Default);
    }
}
