using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class SelectionButtonPresenter : MonoBehaviour
{
    [SerializeField] private SelectionButtonViews _selectionButtonViews;
    [SerializeField] private OriginalLettersModel _originalLettersModel;
    [SerializeField] private OriginalLettersTextView _originalLettersTextView;

    void Start()
    {
        _selectionButtonViews.OnClickObservable.Subscribe( text => {
            _originalLettersModel.SetOriginalLettersModel(text);
        });

        _originalLettersModel.OriginalLetters.Subscribe( text => {
            _originalLettersTextView.Initialize(text);
        });
    }
}
