using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Game : ModelBase
{
    private static Game instance;
    public static Game Instance
    {
        get
        {
            if (instance == null)
                instance = new Game();
            return instance;
        }
    }
    public void Init()
    {
        SceneManager.LoadSceneAsync("Level-1");
        GameScene.Instance.Init();
    }
}