using UnityEngine;
public abstract class Entity
{
    protected GameObject m_Go;
    protected Game m_Game { get { return Game.Instance; } }
    public Entity(GameObject go)
    {
        m_Go = go;
        OnCreate();
    }
    public virtual void OnCreate() { }
    public abstract void OnData();
    public virtual void OnDestroy() { }
}