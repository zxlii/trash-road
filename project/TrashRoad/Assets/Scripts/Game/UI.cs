using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public Vector3 soundCameraPos;
    public GameObject panelPlaying;
    public GameObject panelGameOver;
    public RollText txtCoin;
    public RollText txtScore;
    public Image imgProgress;
    public Image imgProgressFinal;
    public Text txtFinal;
    public Text txtStart;
    public EffectFlyIcons effect;
    private Level m_Level;
    private Car m_Car;

    void Start()
    {
        m_Level = Game.Instance.Lvl;
        m_Car = Game.Instance.Car;
        txtCoin.Change(0, Profile.Instance.Coin);
    }
    public void OnStart()
    {
        m_Car.IsRunning = true;
    }
    public void OnProgress(float progress)
    {
        imgProgress.fillAmount = progress;
    }
    public void OnScore(int increase)
    {
        effect.Fly(increase, 1);
    }

    public void OnHurt(int num)
    {
        Profile.Instance.Coin -= num;
    }

    public void OnGold(int num)
    {
        effect.Fly(num);
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
