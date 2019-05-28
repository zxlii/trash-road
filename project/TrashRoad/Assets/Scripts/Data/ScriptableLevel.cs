using System.Collections.Generic;
using UnityEngine;
public class ScriptableLevel : ScriptableObject
{

    public int Id;
    public int HP;
    public float CarSpeed;
    public int RoadLength
    {
        get
        {
            var len = CarSpeed * PlayTime;
            var blocks = Mathf.RoundToInt(len / 4f);
            return blocks;
        }
    }
    public float PlayTime;
    public int Reward;
    public int ToolClean;
    public int ToolDouble;
    public List<ScriptableLevelItem> Items = new List<ScriptableLevelItem>();
    public float MaxLength
    {
        get
        {
            return RoadLength * 4f;
        }
    }
}