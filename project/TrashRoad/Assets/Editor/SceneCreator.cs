using UnityEditor;
using UnityEngine;
using System.IO;
public class SceneCreator
{
    private static string PrefabSavePath = "/Resources/Prefabs/Levels";
    private static string LevelAssetPath = "/Resources/Levels";
    public static void Execute()
    {
        var levelAssetPath = Application.dataPath + LevelAssetPath;
        if (!Directory.Exists(levelAssetPath))
        {
            Directory.CreateDirectory(levelAssetPath);
            Debug.LogWarning("assets directory does not exist,but this program will create it.");
        }

        var prefabFullPath = Application.dataPath + PrefabSavePath;
        if (!Directory.Exists(prefabFullPath))
            Directory.CreateDirectory(prefabFullPath);

        var assets = Directory.GetFiles(levelAssetPath, "*.asset");
        foreach (var p in assets)
        {
            Create(Path.GetFileNameWithoutExtension(p));
        }
    }

    static void Create(string rootName)
    {
        var data = Resources.Load<ScriptableLevel>("Levels/" + rootName);

        GameObject root = GameObject.Find(rootName);
        if (root != null)
            GameObject.DestroyImmediate(root);

        GameObject roads;
        GameObject items;
        root = new GameObject(rootName);
        roads = new GameObject("roads");
        items = new GameObject("items");
        roads.transform.SetParent(root.transform);
        items.transform.SetParent(root.transform);

        var pos = Vector3.zero;
        var roadUnit = Resources.Load<GameObject>("Prefabs/unit");
        var cnt = data.RoadLength + 20;
        for (int i = 0; i < cnt; i++)
        {
            var roadItem = GameObject.Instantiate<GameObject>(roadUnit, roads.transform);
            roadItem.name = "block-" + (i + 1).ToString();
            pos.z = i * 4;
            roadItem.transform.localPosition = pos;
        }

        var temp = Resources.Load<GameObject>("Prefabs/item");
        var objs = data.Items;
        for (int i = 0; i < objs.Count; i++)
        {
            var obj = objs[i];
            var item = GameObject.Instantiate(temp, items.transform);
            var p = Vector3.zero;
            p.y = 3f;
            p.z = data.RoadLength * 4 * obj.Position;
            item.transform.localPosition = p;
            item.name = "item-" + obj.Id;
            item.tag = obj.Type == 0 ? "Trash" : "Coin";
            var component = item.GetComponent<Item>();
            component.Id = obj.Id;
        }

        root.AddComponent<Level>().Id = data.Id;

        // root.AddComponent<AudioListener>();
        // var asrc = root.AddComponent<AudioSource>();
        // asrc.clip = Resources.Load<AudioClip>("Sounds/BGM");
        // asrc.playOnAwake = true;
        // asrc.loop = true;

        var pathPrefab = "Assets" + PrefabSavePath;
        PrefabUtility.CreatePrefab(path: pathPrefab + Path.DirectorySeparatorChar + root.name + ".prefab", go: root, options: ReplacePrefabOptions.Default);
        GameObject.DestroyImmediate(root);
        AssetDatabase.Refresh();
    }
}