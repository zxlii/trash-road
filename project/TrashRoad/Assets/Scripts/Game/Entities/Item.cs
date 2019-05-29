using UnityEngine;
using UnityEngine.EventSystems;
public class Item : MonoBehaviour
{
    public int Id;
    private ScriptableLevelItem m_Item;
    private GameUI m_UI;
    private float m_ScaleMin = 0.8f;
    private float m_ScaleMax = 5f;
    private float m_MaxGold = 600f;
    private float m_MaxScore = 600f;
    void Start()
    {
        m_UI = Game.Instance.GUI;
        var lvl = Game.Instance.LevelData;
        m_Item = lvl.Items.Find(itm => itm.Id == Id);

        var goldYellow = "#F3B522FF";
        var trashGray = "#76736CFF";

        //87E2F8
        //AF86F8
        Color trashColor1;
        ColorUtility.TryParseHtmlString("#87E2F8", out trashColor1);
        Color trashColor2;
        ColorUtility.TryParseHtmlString("#AF86F8", out trashColor2);

        Color c = Color.green;

        if (m_Item.Type == 0)
        {
            var len = m_ScaleMax - m_ScaleMin;
            var persent = m_Item.Hurt / m_MaxScore;
            var scale = m_ScaleMin + persent * len;
            transform.localScale = Vector3.one * scale;
            c = Color.Lerp(trashColor1, trashColor2, persent);
        }
        else if (m_Item.Type == 1)
        {
            var len = m_ScaleMax - m_ScaleMin;
            var persent = m_Item.Coin / m_MaxGold;
            var scale = m_ScaleMin + persent * len;
            transform.localScale = Vector3.one * scale;
            ColorUtility.TryParseHtmlString("#F3B522FF", out c);
        }

        var rdr = GetComponent<MeshRenderer>();
        rdr.material.SetColor("_Color", c);
        // Color c;
        // if (ColorUtility.TryParseHtmlString(m_Item.Type == 0 ? trashGray : goldYellow, out c))
        //     rdr.material.SetColor("_Color", c);
    }
    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("trigger trash");
        if (other.gameObject.tag.Equals("Car"))
        {
            if (m_Item.Type == 0)
            {
                ManagerAudio.Instance.PlaySound("Hit");
                var damage = m_Item.Hurt;
                var game = Game.Instance;
                game.GLevel.HP -= damage;
                m_UI.OnHurt(damage);
            }
            else if (m_Item.Type == 1)
            {
                m_UI.OnGold(m_Item.Coin);
            }
            Disappear();
        }
    }
    void OnMouseUpAsButton()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (m_Item.Type != 0) return;
        ManagerAudio.Instance.PlaySound("Pick");
        m_UI.OnScore(m_Item.Score);
        Disappear();
    }

    void Disappear()
    {
        //todo 消失特效
        gameObject.SetActive(false);
    }
}