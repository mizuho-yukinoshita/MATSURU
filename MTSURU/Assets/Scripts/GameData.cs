using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public enum Result
    {
        CLEAR,
        GAMEOVER,
        GIVEUP
    }

    public const int COST = 4;
    public static int magicPoint;

    private static int _numComplete;
    public static int NumComplete 
    {
        set
        {
            int d = value - _numComplete;
            _numComplete = value;
            if (d > 0)
            {
                OnCompelte(d);
            }
        }
        get => _numComplete;
    }

    private static int _progress;
    public static int Progress
    {
        set
        {
            _progress = value % COST;
            NumComplete += value / COST;
        }
        get => _progress;
    }

    public static int NumBeat => NumComplete * 4 + Progress;

    public static Dictionary<KeyCode, List<EnemyController>> keyEnemyMap;
    public static Result result;
    public static int timeRemained;

    static GameData()
    {
        Clear();
    }

    public static void Clear()
    {
        magicPoint = 40;
        NumComplete = 0;
        Progress = 0;
        keyEnemyMap = new Dictionary<KeyCode, List<EnemyController>>();
        result = Result.GIVEUP;
        timeRemained = 0;
    }

    public static void AddKeyEnemy(KeyCode key, EnemyController enemy)
    {
        if (!keyEnemyMap.ContainsKey(key))
        {
            keyEnemyMap.Add(key, new List<EnemyController>());
        }
        keyEnemyMap[key].Add(enemy);
    }

    public static EnemyController GetKeyEnemy(KeyCode key)
    {
        if (keyEnemyMap.ContainsKey(key))
        {
            return keyEnemyMap[key][0];
        }
        return null;
    }

    public static bool HasEnemy()
    {
        return keyEnemyMap.Count > 0;
    }

    public static void OnCompelte(int n)
    {
        magicPoint += 3;
        AudioManager.PlaySound(AudioManager.SoundList.SE_COMPLETE);
        ClothGenerator.GenerateCloth();
    }
}
