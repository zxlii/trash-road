using System.Collections.Generic;
using UnityEngine;
public class ScriptableLevel : ScriptableObject
{
    public int Id;
    public int HP;
    public float CarSpeed;
    public float PlayTime;
    public int Reward;
    public int ToolClean;
    public int ToolDouble;
    public List<ScriptableLevelItem> Items = new List<ScriptableLevelItem>();
    public float Length { get { return CarSpeed * PlayTime; } }
    public int LengthBlock { get { return Mathf.RoundToInt(Length / 4f); } }
}