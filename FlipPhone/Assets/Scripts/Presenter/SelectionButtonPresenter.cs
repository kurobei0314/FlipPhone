using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class SelectionButtonPresenter : MonoBehaviour
{
    [SerializeField] private SelectionButtonViews _selectionButtonViews;
    [SerializeField] private SelectionButtonModel _selectionButtonModel;
    [SerializeField] private OriginalLettersModel _originalLettersModel;
    [SerializeField] private NextStepNumModel _nextStepNumModel;
    [SerializeField] private OriginalLettersTextView _originalLettersTextView;

    void Awake()
    {
        _selectionButtonModel.InitializeButtonsObservable.Subscribe( _ => {
            Debug.Log("wa--i");
            _selectionButtonViews.SetText(_selectionButtonModel.Messages);
        }).AddTo(this);

        _selectionButtonViews.OnClickObservable.Subscribe( index => {
            _originalLettersModel.SetOriginalLettersModel(_selectionButtonModel.Messages[index]);
            _nextStepNumModel.SetNextStepNum(_selectionButtonModel.StepNums[index]);
        }).AddTo(this);

        _originalLettersModel.OriginalLetters.Subscribe( text => {
            _originalLettersTextView.Initialize(text);
        }).AddTo(this);
    }
}
