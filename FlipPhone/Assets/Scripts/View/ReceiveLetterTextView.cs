using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReceiveLetterTextView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _letters;

    public void SetText(string letters)
    {
        _letters.text = letters;
    }
}
