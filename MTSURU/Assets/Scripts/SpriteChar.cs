using UnityEngine;
using System.Collections;

public class SpriteChar : MonoBehaviour
{
    // 指定のスプライト番号でスプライトを動的に変更する
    public void SetChar(int idx)
    {
        string name = "number_sprite_" + idx;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Sprite[] sprites = Resources.LoadAll<Sprite>("SpriteFont/number_sprite");
        Sprite sp = System.Array.Find<Sprite>(sprites, (sprite) => sprite.name.Equals(name));
        sr.sprite = sp;
    }
}