using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Car : MonoBehaviour
{
    public bool isRunning = false;
    public Camera m_Camera;
    private GameCar gcar { get { return Game.Instance.GCar; } }
    void Update()
    {
        gcar.Update();
    }
    void OnTriggerEnter(Collider other)
    {
        gcar.OnTriggerEnter(other);
    }
}
