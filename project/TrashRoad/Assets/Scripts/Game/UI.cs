using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static UI Instance;
    void Awake()
    {
        Instance = this;
    }
    public void OnStart()
    {

    }

    public void OnProgress(float progress)
    {

    }

    public void OnScore(int increase)
    {
        Profile.Instance.Coin += increase;
    }

    public void OnHurt(int num)
    {
        Profile.Instance.Coin -= num;
    }

    public void OnGameOver(float progress)
    {

    }

    public void OnUnlock()
    {

    }

    public void OnRestart()
    {

    }
}
