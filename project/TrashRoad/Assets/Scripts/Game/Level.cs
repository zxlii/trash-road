using UnityEngine;
public class Level : MonoBehaviour
{
    public int Id;
    private int m_Score;
    public int Score { get { return m_Score; } set { m_Score = value; } }
    private DataLevel m_LevelData;
    public DataLevel LevelData { get { return m_LevelData; } }
    private UI m_UI;
    private Car m_Car;
    void Start()
    {
        m_LevelData = Game.Instance.LevelData;
        m_UI = Game.Instance.Ui;
        m_Car = Game.Instance.Car;
    }

}