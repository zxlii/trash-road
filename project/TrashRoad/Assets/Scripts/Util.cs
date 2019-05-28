
using System;
using UnityEngine;
using DG.Tweening;

public static class Util
{
    private const string KEY_COIN = "key_coin";
    private const string KEY_LEVEL = "key_level";
    private const string KEY_MUTE = "key_mute";
    private const string KEY_VIBRATE = "key_vibrate";
    private const string KEY_USEDCAR = "key_usedcar";
    public const string KEY_CARPREFIX = "key_carprefix_";
    // 金币
    public static int GetCoin()
    {
        return PlayerPrefs.GetInt(KEY_COIN);
    }
    public static void SetCoin(int value)
    {
        PlayerPrefs.SetInt(KEY_COIN, value);
    }
    // 关卡
    public static int GetLevel()
    {
        return PlayerPrefs.GetInt(KEY_LEVEL);
    }
    public static void SetLevel(int value)
    {
        PlayerPrefs.SetInt(KEY_LEVEL, value);
    }
    //静音
    public static void SetMute(bool value)
    {
        PlayerPrefs.SetInt(KEY_MUTE, value ? 1 : 0);
    }
    public static bool GetMute()
    {
        return PlayerPrefs.GetInt(KEY_MUTE) == 1;
    }
    //震动
    public static void SetVibrate(bool value)
    {
        PlayerPrefs.SetInt(KEY_VIBRATE, value ? 1 : 0);
    }
    public static bool GetVibrate()
    {
        return PlayerPrefs.GetInt(KEY_VIBRATE) == 1;
    }

    public static ModelCar GetCarModelById(int id)
    {
        ModelCar result = null;
        string key = KEY_CARPREFIX + id;
        if (PlayerPrefs.HasKey(key))
        {
            string json = PlayerPrefs.GetString(key);
            result = JsonUtility.FromJson<ModelCar>(json);
        }

        if (result == null)
        {
            result = new ModelCar();
            result.Id = id;
        }
        return result;
    }
    public static T GetModel<T>(string key) where T : ModelBase
    {
        string json = PlayerPrefs.GetString(key);
        T rst = JsonUtility.FromJson<T>(json);
        if (rst == null)
            rst = Activator.CreateInstance<T>();
        return rst;
    }
    public static T GetModel<T>() where T : ModelBase
    {
        string key = ModelBase.GetModelKey(typeof(T).Name);
        return GetModel<T>(key);
    }
    public static void SetModel(string key, ModelBase value)
    {
        PlayerPrefs.SetString(key, value.ToJson());
    }

    public static void DestroyChildren(GameObject go)
    {
        for (int i = go.transform.childCount - 1; i >= 0; --i)
            GameObject.DestroyImmediate(go.transform.GetChild(i).gameObject);
    }

    public static void TweenScaleOneByOne(Transform[] trans, Vector3 start, Vector3 end, float duration, Ease ease = DG.Tweening.Ease.Linear, Action onComplete = null)
    {
        Sequence seq = DOTween.Sequence();
        foreach (var tran in trans)
        {
            tran.localScale = start;
            seq.Append(tran.DOScale(end, duration).SetEase(ease));
        }
        seq.Play().OnComplete(() =>
        {
            seq.Kill(true);
            if (onComplete != null)
                onComplete();
        });
    }
    public static void TweenScaleOneByOne(Transform[] trans, Action onComplete = null)
    {
        TweenScaleOneByOne(trans, Vector3.zero, Vector3.one, .3f, DG.Tweening.Ease.OutBack, onComplete);
    }
}