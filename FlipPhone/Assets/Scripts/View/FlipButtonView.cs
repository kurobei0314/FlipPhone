using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UniRx;

public class FlipButtonView : MonoBehaviour
{
    private Subject<string> onClickItemSubject = new Subject<string>();
    public IObservable<string> OnClickItemObservable => onClickItemSubject;

    public void OnClick(string type)
    {
        onClickItemSubject.OnNext(type);
    }
}
