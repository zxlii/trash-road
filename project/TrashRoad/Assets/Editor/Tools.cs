using UnityEditor;
using UnityEngine;
using System.IO;
public class Tools
{
    [MenuItem("Tools/创建配置文件")]
    static void CreateMasterLevelConfig()
    {
        var obj = ScriptableObject.CreateInstance<LevelConfig>();
        AssetDatabase.CreateAsset(obj, "Assets/Resources/Configs/level-master.asset");
        AssetDatabase.Refresh();
    }

    [MenuItem("Tools/生成关卡数据")]
    static void CreateAllLevelsByConfig()
    {
        LevelCreator.Execute();
    }

    [MenuItem("Tools/生成关卡")]
    static void CreateSceneObjects()
    {
        SceneCreator.Execute();
    }

    [MenuItem("Tools/一键生成")]
    static void CerateAll()
    {
        LevelCreator.Execute();
        SceneCreator.Execute();
    }

    [MenuItem("Tools/清楚本地缓存")]
    static void ClearLocalCache()
    {
        PlayerPrefs.DeleteAll();
    }

    [MenuItem("Tools/打开关卡编辑器")]
    static void Init()
    {
        var win = EditorWindow.GetWindow<LevelEditor>("Level Editor");
        win.Show();
    }
}