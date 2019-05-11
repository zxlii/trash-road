using UnityEngine;

public class ModelBase
{
    public static string GetModelKey(string name)
    {
        return "key_" + name.ToLower();
    }
    protected virtual string key { get { return GetModelKey(GetType().Name); } }
    public string ToJson()
    {
        return ModelBase.ToJson(this);
    }

    public static string ToJson(ModelBase model)
    {
        var s = JsonUtility.ToJson(model);
        return s;
    }

    public void Save()
    {
        if (string.IsNullOrEmpty(key))
        {
            Debug.LogError("the key of model '{0}' is null or empty!");
            return;
        }
        Util.SetModel(key, this);
    }

    public static T Read<T>() where T : ModelBase
    {
        return Util.GetModel<T>();
    }
}