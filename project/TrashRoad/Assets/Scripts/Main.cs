using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public static Main Instance;
    void Awake()
    {

        // var json = Resources.Load("Level-1") as TextAsset;
        // var model = JsonUtility.FromJson<DataLevel>(json.text);
        // Debug.Log(model.objects[0].num);

        // var m = new LevelConfigs();
        // m.level = 1;
        // var item = new ObjectInfo();
        // item.pos = 0.3f;
        // item.num = -4;
        // m.objects.Add(item);
        // Debug.Log(JsonUtility.ToJson(m));

        Instance = this;
        Profile.Instance.Init();
        Game.Instance.Init();
    }
}
