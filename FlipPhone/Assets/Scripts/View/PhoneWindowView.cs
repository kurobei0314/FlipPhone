using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneWindowView : MonoBehaviour
{
    [SerializeField] private GameObject _sendViewGroup;
    [SerializeField] private GameObject _receiveViewGroup;

    public void InitializeAsSendView()
    {
        _sendViewGroup.SetActive(true);
        _receiveViewGroup.SetActive(false);
    }

    public void InitializeAsReceiveView()
    {
        _sendViewGroup.SetActive(false);
        _receiveViewGroup.SetActive(true);
    }
}
