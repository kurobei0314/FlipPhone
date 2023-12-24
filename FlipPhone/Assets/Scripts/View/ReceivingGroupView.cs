using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceivingGroupView : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    public void PlayAnim()
    {
        _animator.Play("ReceivingAnim");
    }
}
