using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public static Main Instance;
    void Awake()
    {
        Instance = this;
        Profile.Instance.Init();
        Game.Instance.Init();
    }
}
