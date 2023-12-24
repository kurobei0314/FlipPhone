using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class ReceivingGroupView : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private Subject<Unit> _finishAnimSubject = new Subject<Unit>();
    public IObservable<Unit> FinishAnimObservable => _finishAnimSubject;

    
    public void PlayAnim()
    {
        _animator.Play("ReceivingAnim");
    }

    public void FinishAnim()
    {
        _finishAnimSubject.OnNext(Unit.Default);
    }
}
