using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteFont))]
public abstract class DynamicText : MonoBehaviour
{
    protected abstract string GetText();
    private SpriteFont sf;

    protected virtual void Start()
    {
        sf = GetComponent<SpriteFont>();
    }

    protected virtual void Update()
    {
        sf.data =  GetText();
    }

    protected string TwoDigitSring(int x)
    {
        return string.Format("{0:d2}", x);
    }
}
