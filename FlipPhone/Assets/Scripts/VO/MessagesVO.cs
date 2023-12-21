using UnityEngine;
using System.Collections.Generic;
using Qitz.DataUtil;


[System.Serializable]
public class MessagesVO 
{
    [SerializeField] private int id;
    public int Id => id;

    [SerializeField] private int type;
    public int Type => type;

    [SerializeField] private string message1;
    public string Message1 => message1;

    [SerializeField] private int step_num1;
    public int StepNum1 => step_num1;

    [SerializeField] private string message2;
    public string Message2 => message2;

    [SerializeField] private int step_num2;
    public int StepNum2 => step_num2;

    [SerializeField] private string message3;
    public string Message3 => message3;

    [SerializeField] private int step_num3;
    public int StepNum3 => step_num3;
}

