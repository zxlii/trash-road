using UnityEditor;
using UnityEngine;
using System.IO;
public class Tools
{
    private static string PrefabSavePath = "/Resources/Prefabs/Levels";
    private static string JsonPath = "/Resources/Levels";

    [MenuItem("Tools/CreateLevels")]
    static void CreateLevels()
    {
        var jsonFullPath = Application.dataPath + JsonPath;
        if (!Directory.Exists(jsonFullPath))
        {
            Directory.CreateDirectory(jsonFullPath);
            Debug.LogWarning("json directory does not exist,but this program will create it.");
        }

        var prefabFullPath = Application.dataPath + PrefabSavePath;
        if (!Directory.Exists(prefabFullPath))
            Directory.CreateDirectory(prefabFullPath);


        var assets = Directory.GetFiles(jsonFullPath, "*.json");
        foreach (var p in assets)
        {
            Create(Path.GetFileNameWithoutExtension(p));
        }
    }

    static void Create(string rootName)
    {
        var json = Resources.Load("Levels/" + rootName) as TextAsset;
        var data = JsonUtility.FromJson<DataLevel>(json.text);

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
        for (int i = 0; i < data.RoadLength; i++)
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
            p.y = 0.7f;
            p.z = (data.RoadLength - 1) * 4 * obj.Position;
            item.transform.localPosition = p;
            item.name = "item-" + obj.Id;

            var component = item.GetComponent<Item>();
            component.Id = obj.Id;
        }

        root.AddComponent<Level>().Id = data.Id;

        var pathPrefab = "Assets" + PrefabSavePath;
        GameObject prefab = PrefabUtility.CreatePrefab(pathPrefab + Path.DirectorySeparatorChar + root.name + ".prefab", root, ReplacePrefabOptions.Default);
        GameObject.DestroyImmediate(root);
        AssetDatabase.Refresh();
    }

    [MenuItem("Tools/ClearLocalCache")]
    static void ClearLocalCache()
    {
        PlayerPrefs.DeleteAll();
    }
}