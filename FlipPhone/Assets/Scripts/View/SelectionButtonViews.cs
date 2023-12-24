using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class SelectionButtonViews : MonoBehaviour
{
    [SerializeField] private SelectionButtonView[] _selectionButtonViews;

    private Subject<int> onClickSubject = new Subject<int>();
    public IObservable<int> OnClickObservable => onClickSubject;

    void Start()
    {
        foreach (var selectionButtonView in _selectionButtonViews)
        {
            selectionButtonView.OnClickItemObservable.Subscribe(index => {
                onClickSubject.OnNext(index);
            }).AddTo(selectionButtonView.gameObject);
        }
    }

    public void SelectionsSetActive(bool isActive)
    {
        this.gameObject.SetActive(isActive);
    }

    public void SetText(string[] letters)
    {
        for (var i = 0; i < letters.Length; i++)
        {
            _selectionButtonViews[i].Initialize(letters[i]);
        }
    }
}
