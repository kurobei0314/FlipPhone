using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class SelectionButtonModel : MonoBehaviour
{
    private int _type;
    public int Type => _type;

    private string[] _messages = new string[3];
    public string[] Messages => _messages;

    private int[] _stepNums = new int[3];
    public int[] StepNums => _stepNums;

    private Subject<Unit> _initializeButtonsSubject = new Subject<Unit>();
    public IObservable<Unit> InitializeButtonsObservable => _initializeButtonsSubject;

    public bool IsActiveSelectionView()
    {
        switch (_type)
        {
            case 2:
                return true;
            case 3:
                return false;
            default:
                return false;
        }
    } 

    public void SetData(MessageDTO messageDTO)
    {
        _type = messageDTO.Type;
        _messages = messageDTO.Messages;
        _stepNums = messageDTO.StepNums;
        _initializeButtonsSubject.OnNext(Unit.Default);
    }
}
