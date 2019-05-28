using UnityEditor;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
public class LevelCreator
{
    static string RootConfigAssetPath;
    static string RootAssetPath;
    static string RootAssetFullPath;

    public static void Execute()
    {
        RootConfigAssetPath = "Assets/Resources/Configs/";
        RootAssetPath = "Assets/Resources/Levels/";
        RootAssetFullPath = Application.dataPath + Path.DirectorySeparatorChar + RootAssetPath;

        var master = AssetDatabase.LoadAssetAtPath<LevelConfig>(RootConfigAssetPath + "level-master.asset");
        for (int i = 0; i < master.Children.Count; i++)
        {
            CreateRegion(master, master.Children[i]);
        }
    }
    static void CreateRegion(LevelConfig master, LevelConfig level)
    {
        var lmin = level.LevelMin;
        var lmax = level.LevelMax;

        var assetPathAbsulote = string.Empty;
        var fileName = string.Empty;
        var assetPath = string.Empty;

        for (var lvl = lmin; lvl <= lmax; lvl++)
        {

            fileName = "level-" + lvl.ToString() + ".asset";
            assetPathAbsulote = RootAssetFullPath + fileName;
            assetPath = RootAssetPath + fileName;

            ScriptableLevel data = File.Exists(assetPathAbsulote) ?
            AssetDatabase.LoadAssetAtPath<ScriptableLevel>(assetPath) :
            ScriptableObject.CreateInstance<ScriptableLevel>();

            data.Id = lvl;
            data.CarSpeed = UseParent(level.SpeedGrowth) ? master.CalcSpeed(lvl) : level.CalcSpeed(lvl);
            data.PlayTime = UseParent(level.TimeGrowth) ? master.CalcTime(lvl) : level.CalcTime(lvl);
            data.Reward = UseParent(level.RewardGrowth) ? master.CalcReward(lvl) : level.CalcReward(lvl);
            data.ToolClean = UseParent(level.ToolCleanGrowth) ? master.CalcToolClean(lvl) : level.CalcToolClean(lvl);
            data.ToolDouble = UseParent(level.ToolDoubleGrowth) ? master.CalcToolDouble(lvl) : level.CalcToolDouble(lvl);

            var items = data.Items;
            var trashCount = level.CalcTrashCount(lvl);
            int coinCount = 1;
            int itemCount = trashCount + coinCount;
            var index = 0;
            for (; index < itemCount; index++)
            {
                var item = new ScriptableLevelItem();
                item.Id = index + 1;
                item.Type = 0;
                items.Add(item);
            }

            //垃圾出现位置生成
            float min = 0.05f;
            float len = 1f - min;
            float unit = len / (float)itemCount;
            for (int i = 0; i < itemCount; i++)
            {
                float left = min + i * unit;
                float right = left + unit;
                float rand = Random.Range(left, right);
                items[i].Position = rand;
            }

            //垃圾积分生成
            int totalScro = level.CalcTrashTotalScore(lvl);
            float average = 1f / (float)trashCount;
            float[] points = new float[trashCount];
            for (int i = 0; i < trashCount; i++)
            {
                float left = average * i;
                float right = average * (i + 1);
                points[i] = Random.Range(left, right);
            }
            float lastValue = 0;
            for (int i = 0; i < trashCount; i++)
            {
                float c1 = lastValue * (float)totalScro;
                float c2 = points[i] * (float)totalScro;
                int score = Mathf.RoundToInt(c2 - c1);
                items[i].Score = score;
                items[i].Hurt = score;
                lastValue = points[i];
            }

            data.HP = Mathf.RoundToInt(totalScro * 0.1f);

            //金币生成
            var coinItem = items[trashCount];
            coinItem.Id = index + 1;
            coinItem.Type = 1;
            coinItem.Coin = level.CalcCoinTotal(lvl);

            AssetDatabase.CreateAsset(data, assetPath);
        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
    static bool UseParent(LevelConfig.GrowthMode gm)
    {
        return gm == LevelConfig.GrowthMode.UseParent;
    }
}