using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UniRx;

public class SelectionButtonView : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _text;

    private Subject<int> onClickItemSubject = new Subject<int>();
    public IObservable<int> OnClickItemObservable => onClickItemSubject;

    public void Initialize(string text)
    {
        _text.text = text;
    }

    public void SetActiveGO(bool isActive)
    {
        this.gameObject.SetActive(isActive);
    }

    public void OnClick(int index)
    {
        AudioManager.Instance.PlaySE("button2");
        onClickItemSubject.OnNext(index);
    }
}
