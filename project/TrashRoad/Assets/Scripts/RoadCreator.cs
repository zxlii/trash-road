using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class RoadCreator : MonoBehaviour
{
    public int count = 5;
    private Transform m_RoadUnit;

    void Awake()
    {
        m_RoadUnit = transform.Find("unit");
    }

    [ContextMenu("Create")]
    void Create()
    {
        var pos = Vector3.zero;
        for (int i = 0; i < count; i++)
        {
            pos.z = i * 4;
            var item = GameObject.Instantiate(m_RoadUnit, transform);
            item.localPosition = pos;
            item.gameObject.SetActive(true);
        }
    }
}
