using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class FlipButtonPresenter : MonoBehaviour
{
    [SerializeField] private FlipButtonView[] _flipButtonViews;
    [SerializeField] private TypingLettersModel _typingLettersModel;

    public void Start()
    {
        foreach (var flipButtonView in _flipButtonViews)
        {
            flipButtonView.OnClickObservable
                .Subscribe (typeNum => {
                    SetLetter(typeNum);
                })
                .AddTo(flipButtonView.gameObject);
        }
    }

}
