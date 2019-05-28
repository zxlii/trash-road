using UnityEngine;

public class GameUI : Entity
{
    private UI m_Component;
    public GameUI(GameObject go) : base(go) { }
    public override void OnCreate()
    {
        m_Component = m_Go.GetComponent<UI>();
        m_Component.togSound.onValueChanged.AddListener(isOn =>
        {
            Profile.Instance.IsMute = !isOn;
        });
        m_Component.togWave.onValueChanged.AddListener(isOn =>
        {
            Profile.Instance.IsVibrate = isOn;
        });
    }

    public override void OnData()
    {
        ShowPanelStart();
    }
    public void ShowPanelStart()
    {
        m_Component.panelPlaying.SetActive(false);
        m_Component.panelGameOver.SetActive(false);
        m_Component.panelStart.SetActive(true);
        m_Component.togSound.isOn = !Profile.Instance.IsMute;
        m_Component.togWave.isOn = Profile.Instance.IsVibrate;
        m_Component.objScore.SetActive(false);
        m_Component.txtCoin.Change(0, Profile.Instance.Coin);
    }
    public void OnStart()
    {
        m_Game.GCar.Run();
        ManagerAudio.Instance.PlayBGM("BGM");
        ShowPanelPlaying();
    }
    public void ShowPanelPlaying()
    {
        m_Component.panelPlaying.SetActive(true);
        m_Component.panelGameOver.SetActive(false);
        m_Component.panelStart.SetActive(false);
        m_Component.objScore.SetActive(true);
        m_Component.txtScore.SetNumber(0, true);
        m_Component.txtHP.text = m_Game.LevelData.HP.ToString();
    }
    public void ShowPanelOver(float progress)
    {
        ManagerAudio.Instance.StopBMG();
        m_Component.panelStart.SetActive(false);
        m_Component.panelPlaying.SetActive(false);
        m_Component.panelGameOver.SetActive(true);
        m_Component.imgProgressFinal.fillAmount = progress;
        m_Component.txtFinalScore.text = m_Game.GLevel.Score.ToString();
        var value = Mathf.RoundToInt(progress * 100f);
        if (value == 100)
        {
            m_Component.txtFinal.text = "PASS";
        }
        else
        {
            m_Component.txtFinal.text = value + "% COMPLETED";
        }

        Util.TweenScaleOneByOne(m_Component.scaleTransforms);
    }

    public void OnScore(int increase)
    {

        m_Component.effect.Fly(m_Game.GLevel.Score, increase, 1);
        m_Game.GLevel.Score += increase;
    }

    public void OnHurt(int num)
    {
        ManagerAudio.Instance.PlaySound("Hit");
        m_Component.effect.FlyNumberText(-num);
        m_Game.GLevel.HP -= num;
        m_Component.txtHP.text = m_Game.GLevel.HP.ToString();
        m_Component.bld.SetValue(m_Game.GLevel.HPPercent);
    }
    public void OnGold(int num)
    {
        m_Component.effect.Fly(Profile.Instance.Coin, num);
        Profile.Instance.Coin += num;
    }
}