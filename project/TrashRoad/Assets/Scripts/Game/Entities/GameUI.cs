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
        m_Component.panelCommon.SetActive(true);
        m_Component.togSound.isOn = !Profile.Instance.IsMute;
        m_Component.togWave.isOn = Profile.Instance.IsVibrate;
        m_Component.objScore.SetActive(false);
        m_Component.txtRollCoin.Change(0, Profile.Instance.Coin);
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
        m_Component.txtLevel.text = "LEVEL " + m_Game.LevelId.ToString();
        m_Component.txtRollScore.SetNumber(0, true);
        m_Component.txtHP.text = "HP " + m_Game.LevelData.HP.ToString();
        m_Component.bld.SetValue(1);
    }
    public void ShowPanelOver()
    {
        ManagerAudio.Instance.StopBMG();
        m_Component.panelStart.SetActive(false);
        m_Component.panelPlaying.SetActive(false);
        m_Component.panelGameOver.SetActive(true);
        m_Component.panelCommon.SetActive(false);

        var gcar = m_Game.GCar;
        float progress = gcar.GetProgress();
        m_Component.imgProgressFinal.fillAmount = progress;

        var hp = m_Game.GLevel.HP;
        var isWin = hp > 0;

        m_Component.score.SetActive(isWin);
        m_Component.btnNext.SetActive(isWin);

        var value = Mathf.RoundToInt(progress * 100f);
        var content = string.Empty;
        var color = Color.white;
        if (isWin)
        {
            content = value == 100 ? "PASS" : value + "% COMPLETED";
            color = value == 100 ? Color.green : Color.white;
            m_Component.txtScore.text = m_Game.GLevel.Score.ToString();

            Profile.Instance.Level = m_Game.LevelId;
        }
        else
        {
            content = "YOU LOST!";
            color = Color.red;
        }
        m_Component.txtFinal.text = content;
        m_Component.txtFinal.color = color;

        Util.TweenScaleOneByOne(m_Component.scaleTransforms);
    }

    public void OnScore(int increase)
    {
        m_Component.effect.Fly(m_Game.GLevel.Score, increase, 1);
        m_Game.GLevel.Score += increase;
    }

    public void OnHurt(int num)
    {
        var hp = m_Game.GLevel.HP;
        m_Component.effect.FlyNumberText(-num);
        m_Component.txtHP.text = "HP " + hp.ToString();
        m_Component.bld.SetValue(m_Game.GLevel.HPPercent);

        if (hp <= 0)
        {
            m_Game.GCar.Stop();
            ShowPanelOver();
        }
    }
    public void OnGold(int num)
    {
        m_Component.effect.Fly(Profile.Instance.Coin, num);
        Profile.Instance.Coin += num;
    }

    public void RollScore(int start, int end)
    {
        m_Component.txtRollScore.Change(start, end);
    }
    public void RollCoin(int start, int end)
    {
        m_Component.txtRollCoin.Change(start, end);
    }
}