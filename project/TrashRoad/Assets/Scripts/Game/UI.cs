using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gear.Runtime.UI;
public class UI : MonoBehaviour
{
    public GameObject panelStart;
    public GameObject panelPlaying;
    public GameObject panelGameOver;

    //panel start
    public Toggle togSound;
    public Toggle togWave;


    //panel playing
    public RollText txtCoin;
    public GameObject objScore;
    public RollText txtScore;
    public GBlood bld;
    public Text txtHP;


    //panel over
    public Image imgProgressFinal;
    public Text txtFinal;
    public Text txtFinalScore;
    public Transform[] scaleTransforms;


    //panel common
    public EffectFlyIcons effect;


    private GameUI gui { get { return Game.Instance.GUI; } }


    public void ShowPanelStart()
    {
        gui.ShowPanelStart();
    }
    public void OnStart()
    {
        gui.OnStart();
    }
    public void ShowPanelPlaying()
    {
        gui.ShowPanelPlaying();
    }

    public void OnRestart()
    {
        Game.Instance.StartLevel(-1);
    }
    public void OnNext()
    {
        Game.Instance.StartLevel(0);
    }
}
