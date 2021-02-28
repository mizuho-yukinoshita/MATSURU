using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumCompleteText : DynamicText
{
    protected override string GetText()
    {
        return TwoDigitSring(GameData.NumComplete);
    }
}
