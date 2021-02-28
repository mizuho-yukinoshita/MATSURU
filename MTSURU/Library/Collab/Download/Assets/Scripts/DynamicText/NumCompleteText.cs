using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumCompleteText : MonoBehaviour
{
    GameObject mp_sprite;
    private void Start()
    {
        mp_sprite = GameObject.Find("NumComplete_Sprite");

    }
    private void Update()
    {
        mp_sprite.GetComponent<SpriteFont>().data = GameData.numComplete.ToString();
    }
}
