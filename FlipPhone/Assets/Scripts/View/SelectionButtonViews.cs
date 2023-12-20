using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class SelectionButtonViews : MonoBehaviour
{
    [SerializeField] private SelectionButtonView[] _selectionButtonViews;

    private Subject<string> onClickSubject = new Subject<string>();
    public IObservable<string> OnClickObservable => onClickSubject;

    void Start()
    {
        foreach (var selectionButtonView in _selectionButtonViews)
        {
            selectionButtonView.OnClickItemObservable.Subscribe(text => {
                onClickSubject.OnNext(text);
            }).AddTo(selectionButtonView.gameObject);
        }
    }
}
