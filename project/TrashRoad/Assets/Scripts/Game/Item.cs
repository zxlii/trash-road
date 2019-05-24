using UnityEngine;
public class Item : MonoBehaviour
{
    public int Id;
    private DataLevelItem m_Item;
    private UI m_UI;
    void Start()
    {
        m_UI = Game.Instance.Ui;
        var lvl = Game.Instance.LevelData;
        m_Item = lvl.Items.Find(itm => itm.Id == Id);
    }
    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("trigger trash");
        if (other.gameObject.tag.Equals("Car"))
        {
            if (m_Item.Type == 0)
            {
                m_UI.OnHurt(m_Item.Hurt);
            }
            else if (m_Item.Type == 1)
            {
                m_UI.OnGold(m_Item.Gold);
            }
            Disappear();
        }
    }
    void OnMouseUpAsButton()
    {
        m_UI.OnScore(m_Item.Score);
        Disappear();
    }

    void Disappear()
    {
        //todo 消失特效
        Destroy(gameObject);
    }
}