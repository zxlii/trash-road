using UnityEngine;
using System.Collections.Generic;

public class GameLevel : Entity
{
    private int m_Score;
    private int m_Gold;
    private int m_HP;
    private Level m_Component;
    private List<Item> m_Items = new List<Item>();
    public int Score { get { return m_Score; } set { m_Score = value; } }
    public int Gold { get { return m_Gold; } set { m_Gold = value; } }
    public int HP { get { return m_HP; } set { m_HP = value; } }
    public float HPPercent
    {
        get
        {
            var v = HP / (float)m_Game.LevelData.HP;
            v = Mathf.Clamp(v, 0, 1f);
            return v;
        }
    }
    public GameLevel(GameObject go) : base(go) { }
    public override void OnData()
    {
        if (m_Game.IsLevelChanged)
        {
            OnDestroy();
            var prefab = Resources.Load<GameObject>("Prefabs/Levels/Level-" + m_Game.LevelId.ToString());
            m_Go = GameObject.Instantiate<GameObject>(prefab);
        }
        m_Component = m_Go.GetComponent<Level>();
        m_Go.GetComponentsInChildren<Item>(true, m_Items);

        m_Score = 0;
        m_Gold = 0;
        m_HP = m_Game.LevelData.HP;
        foreach (var itm in m_Items)
            itm.gameObject.SetActive(true);
    }
    public override void OnDestroy()
    {
        GameObject.Destroy(m_Go);
    }
}