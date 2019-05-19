using UnityEngine;
public class Trash : MonoBehaviour
{
    public int Id;
    private DataTrash trashData;
    public DataTrash TrashData
    {
        get
        {
            if (trashData == null)
                trashData = Static.instance.listTrash.Find(o => o.id == Id);
            return trashData;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger trash");
        if (other.gameObject.tag.Equals("Car"))
        {
            Game.Instance.OnHurt(TrashData.hurt);
            Destroy(gameObject);
        }
    }

    void OnMouseUpAsButton()
    {
        Game.Instance.OnScore(TrashData.income);
        Destroy(gameObject);
    }
}