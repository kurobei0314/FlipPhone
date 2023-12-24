using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftGroupView : MonoBehaviour
{
    [SerializeField] private GameObject _originalLettersGroup;
    [SerializeField] private GameObject _selectionGroup;

    public void InitializeAsOriginalLettersView()
    {
        _originalLettersGroup.SetActive(true);
        _selectionGroup.SetActive(false);
    }

    public void OriginalLettersViewInActive()
    {
        _originalLettersGroup.SetActive(false);
    }

    public void SelectionViewActive()
    {
        _selectionGroup.SetActive(true);
    }
}
