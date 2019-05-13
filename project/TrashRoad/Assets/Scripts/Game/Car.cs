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
    public float Speed = 4.0f;
    private float MaxZ = 300;
    public void Init()
    {

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
                Game.Instance.OnOver(progress);
            }
            transform.localPosition = newPos;

            Game.Instance.OnLevelProgress(progress);
        }
    }

    void OnCollisionEnter(Collision other)
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
