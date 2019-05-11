using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private static Main instance;
    public static Main Instance { get { return instance; } }
    void Awake()
    {
        instance = this;
        Game.Instance.Init();
    }
}
