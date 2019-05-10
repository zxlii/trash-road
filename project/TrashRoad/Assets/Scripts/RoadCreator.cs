using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadCreator : MonoBehaviour
{
    public GameObject temp;
    public int count = 5;
    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            GameObject go = GameObject.Instantiate(temp);
            go.transform.SetParent(transform, false);
            Vector3 pos = Vector3.forward * i * 24;
            go.transform.localPosition = pos;
        }
    }
}
