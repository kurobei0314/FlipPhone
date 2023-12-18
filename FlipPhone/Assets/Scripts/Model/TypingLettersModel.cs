using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingLettersModel : MonoBehaviour
{
    private int prevNum;
    private Dictionary<int, string[]> characterDictionary = new Dictionary<int, string[]>
    {
        { 0, new string[] { "わ", "を", "ん" } },
        { 1, new string[] { "あ", "い", "う", "え", "お" } },
        { 2, new string[] { "か", "き", "く", "け", "こ" } },
        { 3, new string[] { "さ", "し", "す", "せ", "そ" } },
        { 4, new string[] { "た", "ち", "つ", "て", "と" } },
        { 5, new string[] { "な", "に", "ぬ", "ね", "の" } },
        { 6, new string[] { "は", "ひ", "ふ", "へ", "ほ" } },
        { 7, new string[] { "ま", "み", "む", "め", "も" } },
        { 8, new string[] { "や", "ゆ", "よ" } },
        { 9, new string[] { "ら", "り", "る", "れ", "ろ" } },
    };

    void Start()
    {
    }

    public void SetLetter(int typeNum)
    {

    }
}
