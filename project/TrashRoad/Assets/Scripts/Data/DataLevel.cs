using System;
using System.Collections.Generic;
[Serializable]
public class DataLevel
{
    public int Id;
    public int RoadLength;
    public int Reward;
    public int ToolClean;
    public int ToolDouble;
    public List<DataLevelItem> Items = new List<DataLevelItem>();

    public float MaxLength
    {
        get
        {
            return RoadLength * 4f;
        }
    }
}