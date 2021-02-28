using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public KeyCode key;

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        GameData.AddKeyEnemy(key, this);
        SetText(((char)key).ToString().ToUpper());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnDestroy()
    {
        GameData.keyEnemyMap[key].Remove(this);
        if (GameData.keyEnemyMap[key].Count == 0)
        {
            GameData.keyEnemyMap.Remove(key);
        }
    }

    void SetText(string text)
    {
        Text t = transform.Find("Canvas/Text").GetComponent<Text>();
        t.text = text;
    }
}
