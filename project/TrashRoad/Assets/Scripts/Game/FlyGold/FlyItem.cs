using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlyItem : MonoBehaviour
{
    public Action onComplete = null;
    private const float DURATION_STAY = 0.8f;//金币原地停留的时间
    private const float DURATION_MOVE = 0.5f;//金币位置移动用的时间
    private const int SPEED_ANGLE = 180;//金币绕y轴旋转的角速度	度/秒
    private EffectFlyIcons host;
    private Transform target;
    private float rotateTime;
    //初始化到可用状态
    public void Init(EffectFlyIcons host)
    {
        this.host = host;
    }

    public void StartEffect(int index,Transform moveTarget)
    {
        this.target = moveTarget;

        gameObject.SetActive(true);

        //在一个范围内计算随机位置
        var range = 100;
        var x = UnityEngine.Random.Range(-range, range);
        var y = UnityEngine.Random.Range(-range, range);
        var rect = transform as RectTransform;
        rect.anchoredPosition = new Vector2(x, y);

        //因为金币会旋转，为了看起来不那么一致开始的时候给以随机角度
        var angle = UnityEngine.Random.Range(0f, 180f);
        rect.Rotate(0, angle, 0);
        rotateTime = DURATION_STAY + DURATION_MOVE + (index * .01f);

        //金币移动动画Ease用InQuart（先慢后快），通过SetDelay()的时间参数实现一个一个跟随移动的效果
        var stayTime = DURATION_STAY + (index * .01f);
        transform.DOMove(target.position, DURATION_MOVE)
        .SetDelay(stayTime)
        .SetEase(Ease.InQuart)
        .OnComplete(() =>
        {
            gameObject.SetActive(false);
            host.Release(this);
            if (onComplete != null)
            {
                onComplete();
                onComplete = null;
            }
        });
    }

    void Update()
    {
        if (rotateTime <= 0) return;
        var delta = Time.deltaTime * SPEED_ANGLE;
        transform.Rotate(Vector3.up, delta);
        rotateTime -= Time.deltaTime;
    }
}
