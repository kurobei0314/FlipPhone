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
    [SerializeField] private PhoneWindowView _phoneWindowView;
    [SerializeField] private LeftGroupView _leftGroupView;
    [SerializeField] private CurrentLettersTextView _currentLettersTextView;
    [SerializeField] private ReceivingGroupView _receivingGroupView;
    [SerializeField] private TypingLettersModel _typingLettersModel;

    void Awake()
    {
        _selectionButtonModel.InitializeButtonsObservable.Subscribe( _ => {
            _selectionButtonViews.SetText(_selectionButtonModel.Messages);
            _phoneWindowView.InitializeAsReceiveView();
            _leftGroupView.OriginalLettersViewInActive();
        }).AddTo(this);

        _selectionButtonViews.OnClickObservable.Subscribe( index => {
            _originalLettersModel.SetOriginalLettersModel(_selectionButtonModel.Messages[index]);
            _nextStepNumModel.SetNextStepNum(_selectionButtonModel.StepNums[index]);
        }).AddTo(this);

        _originalLettersModel.OriginalLetters.Subscribe( text => {
            _originalLettersTextView.Initialize(text);
            _typingLettersModel.Initialize();
            _currentLettersTextView.Initialize();
            _phoneWindowView.InitializeAsSendView();
            _leftGroupView.InitializeAsOriginalLettersView();
        }).AddTo(this);

        _receivingGroupView.FinishAnimObservable.Subscribe(_ => {
            if (_selectionButtonModel.IsActiveSelectionView())
            {
                _leftGroupView.SelectionViewActive();
            }
        });
    }
}
