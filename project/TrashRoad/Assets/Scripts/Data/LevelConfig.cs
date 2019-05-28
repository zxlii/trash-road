using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelConfig : ScriptableObject
{
    public enum GrowthMode
    {
        Fixed,
        Linear,
        Square,
        UseParent
    }

    public int LevelMin;
    public int LevelMax;
    public float GetLevelDiff()
    {
        return LevelMax - LevelMin;
    }

    public GrowthMode SpeedGrowth = GrowthMode.Linear;
    public float SpeedFixed;
    public float SpeedMin;
    public float SpeedMax;
    public float CalcSpeed(int level)
    {
        return GetGrowthValue(SpeedGrowth, SpeedFixed, SpeedMin, SpeedMax, level);
    }

    public GrowthMode TimeGrowth = GrowthMode.Linear;
    public float TimeFixed;
    public float TimeMin;
    public float TimeMax;
    public float CalcTime(int level)
    {
        return GetGrowthValue(TimeGrowth, TimeFixed, TimeMin, TimeMax, level);
    }

    public GrowthMode RewardGrowth = GrowthMode.Fixed;
    public int RewardFixed;
    public int RewardMin;
    public int RewardMax;
    public int CalcReward(int level)
    {
        return GetGrowthValue(RewardGrowth, RewardFixed, RewardMin, RewardMax, level);
    }

    public GrowthMode ToolCleanGrowth = GrowthMode.Fixed;
    public int ToolCleanFixed;
    public int ToolCleanMin;
    public int ToolCleanMax;
    public int CalcToolClean(int level)
    {
        return GetGrowthValue(ToolCleanGrowth, ToolCleanFixed, ToolCleanMin, ToolCleanMax, level);
    }

    public GrowthMode ToolDoubleGrowth = GrowthMode.Fixed;
    public int ToolDoubleFixed;
    public int ToolDoubleMin;
    public int ToolDoubleMax;
    public int CalcToolDouble(int level)
    {
        return GetGrowthValue(ToolDoubleGrowth, ToolDoubleFixed, ToolDoubleMin, ToolDoubleMax, level);
    }

    public GrowthMode TrashCountGrowth = GrowthMode.Linear;
    public int TrashCountFixed;
    public int TrashCountMin;
    public int TrashCountMax;
    public int CalcTrashCount(int level)
    {
        return GetGrowthValue(TrashCountGrowth, TrashCountFixed, TrashCountMin, TrashCountMax, level);
    }

    public GrowthMode TrashBigCountGrowth = GrowthMode.Linear;
    public int TrashBigCountFixed;
    public int TrashBigCountMin;
    public int TrashBigCountMax;
    public int CalcTrashBigCount(int level)
    {
        return GetGrowthValue(TrashBigCountGrowth, TrashBigCountFixed, TrashBigCountMin, TrashBigCountMax, level);
    }

    public GrowthMode TrashTotalScoreGrowth = GrowthMode.Linear;
    public int TrashTotalScoreFixed;
    public int TrashTotalScoreMin;
    public int TrashTotalScoreMax;
    public int CalcTrashTotalScore(int level)
    {
        return GetGrowthValue(TrashTotalScoreGrowth, TrashTotalScoreFixed, TrashTotalScoreMin, TrashTotalScoreMax, level);
    }

    public GrowthMode TrashTotalHurtGrowth = GrowthMode.Linear;
    public int TrashTotalHurtFixed;
    public int TrashTotalHurtMin;
    public int TrashTotalHurtMax;
    public int CalcTrashTotalHurt(int level)
    {
        return GetGrowthValue(TrashTotalHurtGrowth, TrashTotalHurtFixed, TrashTotalHurtMin, TrashTotalHurtMax, level);
    }

    public GrowthMode CoinTotalGrowth = GrowthMode.Linear;
    public int CoinTotalFixed;
    public int CoinTotalMin;
    public int CoinTotalMax;
    public int CalcCoinTotal(int level)
    {
        return GetGrowthValue(CoinTotalGrowth, CoinTotalFixed, CoinTotalMin, CoinTotalMax, level);
    }

    public List<LevelConfig> Children = new List<LevelConfig>();

    private float GetGrowthValue(GrowthMode growth, float fixedValue, float min, float max, int level)
    {
        var result = 0f;
        if (growth == GrowthMode.Fixed)
        {
            result = fixedValue;
        }
        else if (growth == GrowthMode.Linear)
        {
            result = GetLinearValue(min, max, level);
        }
        else if (growth == GrowthMode.Square)
        {
            result = GetSquareValue(min, max, level);
        }
        return result;
    }
    private int GetGrowthValue(GrowthMode growth, int fixedValue, int min, int max, int level)
    {
        var result = 0;
        if (growth == GrowthMode.Fixed)
        {
            result = fixedValue;
        }
        else if (growth == GrowthMode.Linear)
        {
            result = GetLinearValue(min, max, level);
        }
        else if (growth == GrowthMode.Square)
        {
            result = GetSquareValue(min, max, level);
        }
        return result;
    }

    private float GetLinearValue(float min, float max, int level)
    {
        return Mathf.Lerp(min, max, (level - LevelMin) / GetLevelDiff());
    }
    private int GetLinearValue(int min, int max, int level)
    {
        var v = Mathf.Lerp((float)min, (float)max, (level - LevelMin) / GetLevelDiff());
        return Mathf.RoundToInt(v);
    }
    private float GetSquareValue(float min, float max, int level)
    {
        var diff = max - min;
        var factor = diff / Mathf.Pow(GetLevelDiff(), 2);
        return min + factor * Mathf.Pow(level - LevelMin, 2);
    }
    private int GetSquareValue(int min, int max, int level)
    {
        var diff = max - min;
        var factor = diff / Mathf.Pow(GetLevelDiff(), 2);
        var v = min + factor * Mathf.Pow(level - LevelMin, 2);
        return Mathf.RoundToInt(v);
    }
}
