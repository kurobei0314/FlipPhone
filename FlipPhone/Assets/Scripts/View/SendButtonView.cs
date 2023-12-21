using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

public class SendButtonView : MonoBehaviour
{
    [SerializeField] private Button _button;

    private Subject<int> onClickSendButtonSubject = new Subject<int>();
    public IObservable<int> OnClickSendButtonObservable => onClickSendButtonSubject;

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
        // onClickSendButtonSubject();
    }
}
