using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UniRx;

public class TypingLettersModel : MonoBehaviour
{
    private string _prevType;
    // あ行、か行、さ行
    private int _rowIndex;
    // あ、い、う、え、お
    private int _columnIndex;
    // は、ば、ぱ
    private int _diacriticIndex;

    private string _letters = "";

    private Subject<string> onChangeLettersSubject = new Subject<string>();
    public IObservable<string> OnChangeLettersObservable => onChangeLettersSubject;

    private Dictionary<string, string[]> charactersDictionary = new Dictionary<string, string[]>
    {
        { "0", new string[] { "わ", "を", "ん" } },
        { "1", new string[] { "あ", "い", "う", "え", "お" } },
        { "2", new string[] { "か", "き", "く", "け", "こ" } },
        { "3", new string[] { "さ", "し", "す", "せ", "そ" } },
        { "4", new string[] { "た", "ち", "つ", "て", "と" } },
        { "5", new string[] { "な", "に", "ぬ", "ね", "の" } },
        { "6", new string[] { "は", "ひ", "ふ", "へ", "ほ" } },
        { "7", new string[] { "ま", "み", "む", "め", "も" } },
        { "8", new string[] { "や", "ゆ", "よ" } },
        { "9", new string[] { "ら", "り", "る", "れ", "ろ" } },
        { "00", new string[] { "ゎ", "わ" } },
        { "10", new string[] { "ぁ", "あ" } },
        { "11", new string[] { "ぃ", "い" } },
        { "12", new string[] { "ぅ", "う" } },
        { "13", new string[] { "ぇ", "え" } },
        { "14", new string[] { "ぉ", "お" } },
        { "20", new string[] { "が", "か" } },
        { "21", new string[] { "ぎ", "き" } },
        { "22", new string[] { "ぐ", "く" } },
        { "23", new string[] { "げ", "け" } },
        { "24", new string[] { "ご", "こ" } },
        { "30", new string[] { "ざ", "さ" } },
        { "31", new string[] { "じ", "し" } },
        { "32", new string[] { "ず", "す" } },
        { "33", new string[] { "ぜ", "せ" } },
        { "34", new string[] { "ぞ", "そ" } },
        { "40", new string[] { "だ", "た" } },
        { "41", new string[] { "ぢ", "ち" } },
        { "42", new string[] { "づ", "つ" } },
        { "43", new string[] { "で", "て" } },
        { "44", new string[] { "ど", "と" } },
        { "60", new string[] { "ば", "ぱ", "は" } },
        { "61", new string[] { "び", "ぴ", "ひ" } },
        { "62", new string[] { "ぶ", "ぷ", "ふ" } },
        { "63", new string[] { "べ", "ぺ", "へ" } },
        { "64", new string[] { "ぼ", "ぽ", "ほ" } },
        { "80", new string[] { "ゃ", "や" } },
        { "81", new string[] { "ゅ", "ゆ" } },
        { "82", new string[] { "ょ", "よ" } },
    };

    public void UpdateLetters(string type)
    {

        if (type == "del")
        {
            _letters = RemoveLetter(_letters);
            _prevType = type;
        }
        else
        {
            if (IsSamePreType(type) || type == "*")
            {
                _letters = RemoveLetter(_letters);
            }
            var letter = GetLetter(type);
            _letters = _letters + letter;
        }
        onChangeLettersSubject.OnNext(_letters);
    }

    private bool IsSamePreType(string type) => _prevType == type;

    private string RemoveLetter(string letters)
    {
        if (letters.Length != 0)
        {
            letters = letters.Remove(_letters.Length - 1);
        }
        return letters;
    }

    private bool IsContainsKey(string type)
    {
        switch(type)
        {
            case "*":
                var key = String.Concat(_rowIndex, _columnIndex);
                return charactersDictionary.ContainsKey(key);
            default:
                return charactersDictionary.ContainsKey(_rowIndex.ToString());
        }
    }

    private string GetLetter(string type)
    {
        string letter = "";
        switch (type)
        {
            case "*":
                letter = GetDiacriticLetter(type);
                break;
            case "del":
                break;
            default:
                letter = GetUnDiacriticLetter(type);
                break;
        }
        return letter;
    }

    private string GetDiacriticLetter(string type)
    {
        // 前に選択したボタンと同じ時は、次の文字を入れる
        if (IsSamePreType(type))
        {
            // キーがなかった場合、元の文字を返す
            if (!IsContainsKey(type))
            {
                var characters = charactersDictionary[_rowIndex.ToString()];
                return characters[_columnIndex];
            } 
            else
            {
                var key = String.Concat(_rowIndex, _columnIndex);
                var characters = charactersDictionary[key];
                _diacriticIndex = (_diacriticIndex + 1) % characters.Length;
                return characters[_diacriticIndex];
            }
        }
        // 前に選択したボタンと同じでない時は、別の文字に上書きする
        else
        {
            _prevType = type;
            // キーがなかった場合、元の文字を返す
            if (!IsContainsKey(type))
            {
                var characters = charactersDictionary[_rowIndex.ToString()];
                return characters[_columnIndex];
            } 
            else
            {
                _diacriticIndex = 0;
                var key = String.Concat(_rowIndex, _columnIndex);
                var characters = charactersDictionary[key];
                return characters[_diacriticIndex];
            }
        }
    }
    private string GetUnDiacriticLetter(string type)
    {
        // 前に選択したボタンと同じ時は、次の文字を入れる
        if (IsSamePreType(type))
        {
            var characters = charactersDictionary[_rowIndex.ToString()];
            _columnIndex = (_columnIndex + 1) % characters.Length;
            return characters[_columnIndex];
        }
        // 前に選択したボタンと同じでない時は、別の文字に上書きする
        else
        {
            _prevType = type;
            _rowIndex = int.Parse(type);
            _columnIndex = 0;
            var characters = charactersDictionary[_rowIndex.ToString()];
            return characters[_columnIndex];
        }
    }
}
