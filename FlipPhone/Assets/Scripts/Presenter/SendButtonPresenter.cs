using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class SendButtonPresenter : MonoBehaviour
{
    [SerializeField] private SendButtonView _sendButtonView;
    [SerializeField] private NextStepNumModel _nextStepNumModel;

    private Subject<int> onClickSendButtonSubject = new Subject<int>();
    public IObservable<int> OnClickSendButtonObservable => onClickSendButtonSubject;

    void Awake()
    {
        _sendButtonView.OnClickSendButtonObservable.Subscribe(_ => {
            onClickSendButtonSubject.OnNext(_nextStepNumModel.NextStepNum);
        });
    }

}
