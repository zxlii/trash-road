using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public GameObject panelPlaying;
    public GameObject panelGameOver;
    public Image imgProgress;
    public Text txtCoin;
    public Image imgProgressFinal;
    public Text txtFinal;
    public Text txtStart;
    public void Init()
    {

    }
    public void OnStart()
    {
        Game.Instance.car.IsRunning = true;
    }

    public void OnProgress(float progress)
    {
        imgProgress.fillAmount = progress;
    }

    public void OnScore(int increase)
    {
        Profile.Instance.Coin += increase;
        txtCoin.text = Profile.Instance.Coin.ToString();
    }

    public void OnHurt(int num)
    {
        Profile.Instance.Coin -= num;
    }

    public void OnGameOver(float progress)
    {
        panelPlaying.SetActive(false);
        panelGameOver.SetActive(true);
        imgProgressFinal.fillAmount = progress;
        var value = Mathf.RoundToInt(progress * 100f);
        if (value == 100)
        {
            txtFinal.text = "PASS";
            txtStart.text = "NEXT";
        }
        else
        {
            txtFinal.text = value + "% COMPLETED";
            txtStart.text = "RESTART";
        }
    }

    public void OnUnlock()
    {

    }

    public void OnRestart()
    {

    }
}
