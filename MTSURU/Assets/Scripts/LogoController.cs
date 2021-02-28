using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoController : MonoBehaviour
{
    // 開始からのフレーム数
    int framecount = 0;
    // 画像の透明度
    float a = 0;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeTransparency(0); // 完全に透明にする
    }
    private void Update()
    {
        LogoAnimate();
        ChangeTransparency(a);
        framecount++;
    }
    void ChangeTransparency(float alpha)
    {
        this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
    }

    void LogoAnimate()
    {
        if(framecount <= 60)
        {
            a+=0.05f;
        }
        if(framecount <= 120)
        {
            return;
        }else
        {
            a -= 0.05f;
        }
        if(a < 0 && framecount >= 200)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }


}
