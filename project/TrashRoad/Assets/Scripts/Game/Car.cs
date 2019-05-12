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
    void Update()
    {
        if (IsRunning)
        {
            var delta = Vector3.zero;
            delta.z += Time.deltaTime * Speed;
            var newPos = transform.localPosition + delta;
            if (newPos.z >= MaxZ)
            {
                newPos.z = MaxZ;
                isRunning = false;
            }
            transform.localPosition = newPos;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Trash"))
        {

        }
        else if (other.gameObject.tag.Equals("Coin"))
        {

        }
    }
}
