using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class FlipButtonPresenter : MonoBehaviour
{
    [SerializeField] private FlipButtonViews _flipButtonViews;
    [SerializeField] private TypingLettersModel _typingLettersModel;
    [SerializeField] private CurrentLettersTextView _currentLettersTextView;
    [SerializeField] private OriginalLettersModel _originalLettersModel;
    [SerializeField] private SendButtonView _sendButtonView;

    public void Start()
    {
        _flipButtonViews.OnClickObservable
            .Subscribe(type => {
                _typingLettersModel.UpdateLetters(type);
            }).AddTo(_flipButtonViews.gameObject);

        _typingLettersModel.OnChangeLettersObservable
            .Subscribe(letters => {
                _currentLettersTextView.UpdateCurrentLettersText(letters);
                _sendButtonView.UpdateInteractable(_originalLettersModel.IsSameCurrentLetters(letters));
        }).AddTo(_flipButtonViews.gameObject);
    }
}
