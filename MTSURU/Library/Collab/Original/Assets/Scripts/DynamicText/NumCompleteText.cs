using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumCompleteText : DynamicText
{
    public override string GetText()
    {
        return GameData.NumComplete.ToString();
    }
}
