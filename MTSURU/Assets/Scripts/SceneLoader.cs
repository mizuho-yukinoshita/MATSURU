using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public enum Scene
    {
        TitleScene,
        TutorialScene,
        MainScene,
        ResultScene
    }

    public enum Mode
    {
        NORMAL,
        ASYNC
    }

    public Mode mode;
    public KeyCode key;
    public Scene scene;

    void Start()
    {
        switch (mode)
        {
            case Mode.NORMAL:
                StartCoroutine(NormalLoader(scene, key));
                break;
            case Mode.ASYNC:
                StartCoroutine(AsyncLoader(scene, key));
                break;
        }
        
    }

    public static void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public static IEnumerator NormalLoader(Scene scene, KeyCode key)
    {
        yield return new WaitUntil(GetKeyDownFunc(key));
        SceneManager.LoadScene(scene.ToString());
    }

    public static IEnumerator AsyncLoader(Scene scene, KeyCode key)
    {
        var load = SceneManager.LoadSceneAsync(scene.ToString());
        load.allowSceneActivation = false;
        yield return new WaitUntil(GetKeyDownFunc(key));
        load.allowSceneActivation = true;
    }

    private static Func<bool> GetKeyDownFunc(KeyCode key)
    {
        return () => Input.GetKeyDown(key);
    }
}
