using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    Enemy[] enemies;
    static Random random = new Random();
    const int NUM_POS = 3;
    readonly Vector3[] positions = { 
        new Vector3(3.19f, 1.55f, 0), 
        new Vector3(5.64f, 1.19f, 0), 
        new Vector3(8.01f, 0.97f, 0) 
    };
    static GameObject[] enemyObjects = { null, null, null };
    static int[] order = Enumerable.Range(0, NUM_POS).ToArray();
    Queue<Enemy> enemyQueue = new Queue<Enemy>();

    private class Enemy
    {
        static Dictionary<char, KeyCode> colorKeyMap = new Dictionary<char, KeyCode>();

        static Enemy()
        {
            colorKeyMap.Add('R', KeyCode.Z);
            colorKeyMap.Add('G', KeyCode.X);
            colorKeyMap.Add('B', KeyCode.C);
            colorKeyMap.Add('O', KeyCode.V);
        }

        public Sprite sprite;
        public string name;
        public KeyCode key;

        public static Enemy[] FromSprites(Sprite[] sprites)
        {
            int n = sprites.Length;
            Enemy[] enemies = new Enemy[n];
            for (int i = 0; i < n; i++)
            {
                Enemy e = new Enemy();
                e.sprite = sprites[i];
                e.name = sprites[i].name;
                e.key = colorKeyMap[e.name[2]];
                enemies[i] = e;
            }
            return enemies;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Enemies");
        enemies = Enemy.FromSprites(sprites);
    }

    private void Start()
    {
        StartCoroutine(AddEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        GenerateEnemy();
    }

    private T RandomPick<T>(T[] items)
    {
        int i = Random.Range(0, items.Length);
        return items[i];
    }

    private IEnumerator AddEnemy()
    {
        float interval = 3;
        while (true)
        {
            float shift = Random.Range(-0.5f, 0.5f);
            yield return new WaitForSeconds(interval + shift);
            interval = Mathf.Max(1, interval * 0.95f);
            enemyQueue.Enqueue(RandomPick(enemies));
        }
    }

    private void GenerateEnemy()
    {
        order = order.OrderBy(i => System.Guid.NewGuid()).ToArray();
        foreach (int i in order)
        {
            if (enemyObjects[i] == null)
            {
                enemyObjects[i] = DequeueEnemy(positions[i]);
            }
        }
    }

    private GameObject DequeueEnemy(Vector3 pos)
    {
        if (enemyQueue.Count == 0)
        {
            return null;
        }
        Enemy e = enemyQueue.Dequeue();
        GameObject enemy = Instantiate<GameObject>(enemyPrefab);
        enemy.GetComponent<SpriteRenderer>().sprite = e.sprite;
        enemy.GetComponent<EnemyController>().key = e.key;
        enemy.transform.position = pos;
        return enemy;
    }
}
