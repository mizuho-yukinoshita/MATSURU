using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPointText : DynamicText
{
    protected override string GetText()
    {
        return TwoDigitSring(GameData.magicPoint);
    }
}
