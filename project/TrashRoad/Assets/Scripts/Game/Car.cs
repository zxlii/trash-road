using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField]
    private bool isRunning = false;
    public bool IsRunning
    {
        get { return isRunning; }
        set { isRunning = value; }
    }
    public float Speed = 6.0f;
    private float MaxZ = 300;
    private Level m_Level;
    private DataLevel m_LevelData;
    private UI m_UI;

    void Start()
    {
        m_LevelData = Game.Instance.LevelData;
        m_UI = Game.Instance.Ui;
        m_Level = Game.Instance.Lvl;
        MaxZ = m_LevelData.MaxLength;
    }
    void Update()
    {
        if (IsRunning)
        {
            var delta = Vector3.zero;
            delta.z += Time.deltaTime * Speed;
            var newPos = transform.localPosition + delta;
            var progress = newPos.z / MaxZ;
            if (newPos.z >= MaxZ)
            {
                newPos.z = MaxZ;
                isRunning = false;
                m_UI.OnGameOver(progress);
            }
            transform.localPosition = newPos;
            m_UI.OnProgress(progress);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Trash"))
        {
            // Debug.Log(other.gameObject.name);
            // var newPos = transform.localPosition + Vector3.up * .2f;
            // transform.localPosition = newPos;
        }
        else if (other.gameObject.tag.Equals("Coin"))
        {

        }
    }
}
