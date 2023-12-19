using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class FlipButtonViews : MonoBehaviour
{
    [SerializeField] private FlipButtonView[] _flipButtonViews = null;

    private Subject<string> onClickSubject = new Subject<string>();
    public IObservable<string> OnClickObservable => onClickSubject;

    public void Start()
    {
        foreach (var flipButtonView in _flipButtonViews)
        {
            flipButtonView.OnClickItemObservable
                .Subscribe (type => {
                    onClickSubject.OnNext(type);
                }).AddTo(flipButtonView.gameObject);
        }
    }
}