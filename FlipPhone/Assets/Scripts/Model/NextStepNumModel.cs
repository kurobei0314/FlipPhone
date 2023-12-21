using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStepNumModel : MonoBehaviour
{
    private int next_step_num;
    public int NextStepNum => next_step_num;

    public void SetNextStepNum (int step_num)
    {
        next_step_num = step_num;
    }

}
