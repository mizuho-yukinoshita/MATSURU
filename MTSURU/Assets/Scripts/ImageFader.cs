using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageFader : MonoBehaviour
{
    public float speed = 5;
    public float interval = 0;

    Image image;
    float Alpha => image.color.a;
    float Red => image.color.r;
    float Green => image.color.g;
    float Blue => image.color.b;

    private void Awake()
    {
        image = GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Blink(speed, interval, BlinkCondition));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected virtual bool BlinkCondition()
    {
        float threshold = 0.6f;
        float ratio = DoorController.openDuration / DoorController.TIMEOUT;
        return ratio > threshold;
    }

    private IEnumerator ChangeAlpha(float alpha, float time)
    {
        float delta = alpha - Alpha;
        float speed = delta / time;
        while ((Alpha - alpha) * delta < 0)
        {
            image.color = new Color(Red, Green, Blue, Alpha + speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator Blink(float speed, float interval, Func<bool> Cond)
    {
        float time = 1 / speed;
        while (true)
        {
            yield return new WaitUntil(Cond);
            yield return StartCoroutine(ChangeAlpha(1, time));
            yield return StartCoroutine(ChangeAlpha(0, time));
            yield return new WaitForSeconds(interval);
        }
    }
}
