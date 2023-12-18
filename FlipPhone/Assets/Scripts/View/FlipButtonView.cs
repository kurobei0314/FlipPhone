using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UniRx;

public class FlipButtonView : MonoBehaviour
{
    private Subject<int> onClickSubject = new Subject<int>();
    public IObservable<int> OnClickObservable => onClickSubject;

    public void OnClick(int num)
    {
        onClickSubject.OnNext(num);
    }
}
