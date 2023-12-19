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

    public void Start()
    {
        _flipButtonViews.OnClickObservable
            .Subscribe(type => {
                _typingLettersModel.UpdateLetters(type);
            }).AddTo(_flipButtonViews.gameObject);

        _typingLettersModel.OnChangeLettersObservable
            .Subscribe(letters => {
                _currentLettersTextView.UpdateCurrentLettersText(letters);
        }).AddTo(_flipButtonViews.gameObject);
    }
}
