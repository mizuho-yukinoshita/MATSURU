using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneController : MonoBehaviour
{
    public int fps = 1;
    public int anime_count = 0;
    public Sprite crane_1;
    public Sprite crane_2;
    public Sprite crane_attack;
    private static bool is_attacking = false;
    private float Interval => 1.0f / fps;
    private float elapsedTime;

    private GameObject beam;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = crane_1;
        is_attacking = false;
        elapsedTime = 0;
        beam = transform.Find("Beam").gameObject;
        beam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (is_attacking)
        {
            this.GetComponent<SpriteRenderer>().sprite = crane_attack;
            beam.SetActive(true);
            if (elapsedTime >= Interval*2)
            {
                is_attacking = !is_attacking;
                beam.SetActive(false);
            }
        }
        else
        if (elapsedTime >= Interval)
        {
            if (this.GetComponent<SpriteRenderer>().sprite == crane_1)
            {
                this.GetComponent<SpriteRenderer>().sprite = crane_2;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().sprite = crane_1;
            }
            elapsedTime -= Interval;
        }
    }
    public static void AttackStart()
    {
        is_attacking = true;
    }

}
