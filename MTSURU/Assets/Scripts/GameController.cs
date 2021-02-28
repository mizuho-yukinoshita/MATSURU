using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    static KeyCode[] validKeys = { KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V, KeyCode.Escape };
    int totalTime = 90;
    float elapsedTime;
    int TimeRemained => Mathf.CeilToInt(totalTime - elapsedTime);
    
    private void Awake()
    {
        GameData.Clear();
        GameData.timeRemained = totalTime;
    }
    void Start()
    {
        elapsedTime = 0;
        AudioManager.PlaySound(AudioManager.SoundList.MUSIC);
    }

    // Update is called once per frame
    void Update()
    {
        HandleKeyInput();
        UpdateTimer();
    }

    void HandleKeyInput()
    {
        bool validInput = validKeys.Any(key => Input.GetKeyDown(key));
        if (validInput && GameData.magicPoint > 0)
        {
            GameData.magicPoint -= 1;
            foreach (KeyCode key in GameData.keyEnemyMap.Keys)
            {
                if (Input.GetKeyDown(key))
                { 
                    OnEnemyMatch(GameData.GetKeyEnemy(key));
                    CraneController.AttackStart();
                    return;
                }
            }
            AudioManager.PlaySound(AudioManager.SoundList.SE_WRONG);
        }
    }

    void OnEnemyMatch(EnemyController enemy)
    {
        Destroy(enemy.gameObject);
        AudioManager.PlaySound(AudioManager.SoundList.SE_RIGHT);
        GameData.Progress += 1;
    }

    public static void ShowResult(GameData.Result result)
    {
        GameData.result = result;
        SceneLoader.LoadScene(SceneLoader.Scene.ResultScene);
    }

    void UpdateTimer()
    {
        elapsedTime += Time.deltaTime;
        GameData.timeRemained = TimeRemained;
        if (TimeRemained <= 0)
        {
            ShowResult(GameData.Result.GAMEOVER);
        }
    }
}
