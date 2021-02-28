using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressText : DynamicText
{
    protected override void Start()
    {
        base.Start();
        GameObject cost_sprite = GameObject.Find("Cost_Sprite");
        cost_sprite.GetComponent<SpriteFont>().data = GameData.COST.ToString();
    }

    protected override string GetText()
    {
        return GameData.Progress.ToString();
    }
}
