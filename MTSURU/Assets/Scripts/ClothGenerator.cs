using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothGenerator : MonoBehaviour
{
    public GameObject clothPrefab;
    public Vector3 initPositon = new Vector3(4.3f, -4f, 0);
    public Vector3 padding = new Vector3(0, 0.4f, 0);

    private static ClothGenerator generator = null;
    private static int n = 0;
    public static void Clear()
    {
        n = 0;
    }

    void Start()
    {
        generator = this;
        Clear();
    }

    void Update()
    {
        
    }



    public static void GenerateCloth()
    {
        GameObject cloth = Instantiate<GameObject>(generator.clothPrefab);
        Vector3 pos = generator.initPositon + n * generator.padding;
        cloth.transform.position = pos;
        cloth.transform.parent = generator.transform;
        n += 1;
    }
}
