using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class SelectionButtonModel : MonoBehaviour
{
    private string[] _messages = new string[3];
    public string[] Messages => _messages;

    private int[] _stepNums = new int[3];
    public int[] StepNums => _stepNums;

    private Subject<Unit> _initializeButtonsSubject = new Subject<Unit>();
    public IObservable<Unit> InitializeButtonsObservable => _initializeButtonsSubject;

    public void SetData(MessageDTO messageDTO)
    {
        _messages = messageDTO.Messages;
        _stepNums = messageDTO.StepNums;
        _initializeButtonsSubject.OnNext(Unit.Default);
    }
}
