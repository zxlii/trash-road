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

    public UI ui;
    public Car car;
    public void Init()
    {
        ui = GameObject.Find("Main/UIRoot").GetComponent<UI>();
        ui.Init();

        car = GameObject.Find("car").GetComponent<Car>();
        car.Init();
    }

    public void OnLevelProgress(float value)
    {
        ui.OnProgress(value);
    }

    public void OnScore(int num)
    {
        ui.OnScore(num);
    }
    public void OnHurt(int num)
    {
        ui.OnHurt(num);
    }

    public void OnOver(float value)
    {
        ui.OnGameOver(value);
    }
}