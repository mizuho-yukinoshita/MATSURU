using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultTitle : DynamicText
{
    protected override string GetText()
    {
        return GameData.result.ToString();
    }
}
