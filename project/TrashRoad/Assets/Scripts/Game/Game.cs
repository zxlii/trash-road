using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Game
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

    public UI Ui;
    public Car Car;
    public Level Lvl;
    public DataLevel LevelData;
    public void Init()
    {
        var lvl = Profile.Instance.Level + 1;
        LevelData = JsonUtility.FromJson<DataLevel>(Resources.Load<TextAsset>("Levels/level-" + lvl.ToString()).text);

        var prefab = Resources.Load<GameObject>("Prefabs/ui");
        var go = GameObject.Instantiate(prefab);
        Ui = go.GetComponent<UI>();

        prefab = Resources.Load<GameObject>("Prefabs/Levels/Level-" + lvl.ToString());
        go = GameObject.Instantiate<GameObject>(prefab);
        Lvl = go.GetComponent<Level>();

        prefab = Resources.Load<GameObject>("Prefabs/car");
        go = GameObject.Instantiate<GameObject>(prefab);
        Car = go.GetComponent<Car>();
    }
}