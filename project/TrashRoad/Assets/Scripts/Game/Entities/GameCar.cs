using UnityEngine;
using DG.Tweening;

public class GameCar : Entity
{
    private float m_Speed;
    private float m_Maxz = 300;
    private Car m_Component;
    private Camera m_Camera;
    public GameCar(GameObject go) : base(go) { }

    public override void OnCreate()
    {
        m_Component = m_Go.GetComponent<Car>();
    }
    public override void OnData()
    {
        var levelData = m_Game.LevelData;
        m_Speed = levelData.CarSpeed;
        m_Maxz = levelData.MaxLength;

        var pos = m_Go.transform.localPosition;
        pos.z = 0;
        m_Go.transform.localPosition = pos;
    }
    public void Update()
    {
        if (m_Component.isRunning)
        {
            var delta = Vector3.zero;
            delta.z += Time.deltaTime * m_Speed;
            var newPos = m_Go.transform.localPosition + delta;
            var progress = newPos.z / m_Maxz;
            if (newPos.z >= m_Maxz)
            {
                newPos.z = m_Maxz;
                m_Component.isRunning = false;
                m_Game.GUI.ShowPanelOver(progress);
            }
            m_Go.transform.localPosition = newPos;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Trash"))
        {
            m_Component.m_Camera.DOShakePosition(0.3f, 1, 30);
        }
        else if (other.gameObject.tag.Equals("Coin"))
        {

        }
    }
    public void Run()
    {
        m_Component.isRunning = true;
    }

}