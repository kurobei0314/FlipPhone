using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendButtonView : MonoBehaviour
{
    [SerializeField] private Button _button;

    public void Start()
    {
        _button.interactable = false;
    }

    public void UpdateInteractable(bool isSameLetters)
    {
        _button.interactable = isSameLetters;
    }
}
