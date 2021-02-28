using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumBeat : DynamicText
{
    protected override string GetText()
    {
        return TwoDigitSring(GameData.NumBeat);
    }
}
