using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageDTO
{
    private int id;
    public int Id => id;

    private int type;
    public int Type => type;
    
    private string[] messages;
    public string[] Messages => messages;

    private int[] step_nums;
    public int[] StepNums => step_nums;

    public MessageDTO(MessagesVO message)
    {
        id = message.Id;
        type = message.Type;
        messages = new string[] { message.Message1, message.Message2, message.Message3 };
        step_nums = new int[] { message.StepNum1, message.StepNum2, message.StepNum3 };
    }
}
