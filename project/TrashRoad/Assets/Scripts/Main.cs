using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public static Main Instance;
    void Awake()
    {
        GameObject.DontDestroyOnLoad(this);
        Instance = this;
        StartCoroutine(Init());
    }

    IEnumerator Init()
    {
        var json = Resources.Load("Config") as TextAsset;
        JsonUtility.FromJson<Static>(json.text);
        Profile.Instance.Init();
        yield return null;

        AsyncOperation async = SceneManager.LoadSceneAsync("Level-1");
        while (!async.isDone)
        {

            yield return async;
        }

        Game.Instance.Init();
    }
}
