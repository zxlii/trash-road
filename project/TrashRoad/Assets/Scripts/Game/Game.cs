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
    public ScriptableLevel LevelData
    {
        get
        {
            return m_LevelData;
        }
    }


    private GameUI m_UI;
    public GameUI GUI { get { return m_UI; } }
    private GameCar m_Car;
    public GameCar GCar { get { return m_Car; } }
    private GameLevel m_Level;
    public GameLevel GLevel { get { return m_Level; } }
    private int m_LevelId;
    public int LevelId { get { return m_LevelId; } }
    private ScriptableLevel m_LevelData;
    private bool m_IsLevelChanged = false;
    public bool IsLevelChanged { get { return m_IsLevelChanged; } }

    private GameObject m_GoCar;
    private GameObject m_GoGUI;
    private GameObject m_GoLevel;
    public void Init()
    {
        Load();
        Create();
        StartLevel(0);
    }

    private void Load()
    {
        var prefab = Resources.Load<GameObject>("Prefabs/car");
        m_GoCar = GameObject.Instantiate<GameObject>(prefab);
        prefab = Resources.Load<GameObject>("Prefabs/ui");
        m_GoGUI = GameObject.Instantiate(prefab);
        prefab = Resources.Load<GameObject>("Prefabs/Levels/Level-" + (Profile.Instance.Level + 1).ToString());
        m_GoLevel = GameObject.Instantiate<GameObject>(prefab);
    }

    private void Create()
    {
        m_UI = new GameUI(m_GoGUI);
        m_Car = new GameCar(m_GoCar);
        m_Level = new GameLevel(m_GoLevel);
    }

    //情况1:level<0,开始当前关，即重新开始。
    //情况2:level==0,开始下一关。
    //情况3:level>0,level只能事levelId，表示开始levelId表示的关。
    public void StartLevel(int level = -1)
    {
        int lid;
        if (level < 0)
            lid = m_LevelId;
        else if (level == 0)
            lid = Profile.Instance.Level + 1;
        else
            lid = level;
        m_IsLevelChanged = lid != m_LevelId;
        m_LevelId = lid;
        m_LevelData = Resources.Load<ScriptableLevel>("Levels/level-" + lid.ToString());

        m_UI.OnData();
        m_Car.OnData();
        m_Level.OnData();

        m_IsLevelChanged = false;
    }
}