using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerText : DynamicText
{
    protected override string GetText()
    {
        return TwoDigitSring(GameData.timeRemained);
    }
}
