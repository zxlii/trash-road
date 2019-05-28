using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class EffectFlyIcons : MonoBehaviour
{
    public RollText rt;
    private const int little = 12;
    private const int more = 30;
    [SerializeField]
    private FlyItem item;
    [SerializeField]
    private Text txtNum;
    [SerializeField]
    private Transform[] targets;
    [SerializeField]
    private Sprite[] sprites;
    public Queue<FlyItem> queue = new Queue<FlyItem>();
    private int origin;
    private int increase;
    void Awake()
    {
        for (var i = 0; i < more; i++)
        {
            var newItem = GameObject.Instantiate<FlyItem>(item, transform);
            newItem.Init(this);
            queue.Enqueue(newItem);
        }
    }
    private FlyItem last = null;
    private int type;
    //0飞金币，1飞积分
    public void Fly(int origin, int inc, int type = 0)
    {
        this.origin = origin;
        this.increase = inc;
        this.type = type;

        FlyNumberText(inc);

        var target = targets[type];
        var sprite = sprites[type];
        ManagerAudio.Instance.PlaySound("AddGold");
        var realCount = inc > 200 ? more : little;
        if (queue.Count < realCount) return;
        for (int i = 0; i < realCount; i++)
        {
            var item = queue.Dequeue();
            var img = item.GetComponent<Image>();
            img.sprite = sprite;
            var size = Vector2.one * 60;
            if (type == 1)
            {
                size.x = 30;
                size.y = 61;
            }
            img.rectTransform.sizeDelta = size;

            item.StartEffect(i, target);
            if (i == realCount - 1)
            {
                last = item;
            }
        }
    }

    public void FlyNumberText(int num)
    {
        var txt = GameObject.Instantiate<Text>(txtNum, txtNum.transform.parent);
        txt.gameObject.SetActive(true);
        txt.text = (num > 0 ? "+" : "") + num.ToString();
        txt.color = num > 0 ? Color.green : Color.red;
        txt.DOFade(0, 2f);
        txt.rectTransform.DOAnchorPosY(txt.rectTransform.anchoredPosition.y + 120, 2.5f)
        .SetEase(Ease.InCirc)
        .OnComplete(() => GameObject.Destroy(txt.gameObject));
    }

    public void Release(FlyItem item)
    {
        queue.Enqueue(item);
        if (item == last)
        {
            if (type == 0)
            {
                int num2 = origin + increase;
                Game.Instance.Ui.txtCoin.Change(origin, num2);
            }
            else if (type == 1)
            {
                int num2 = origin + increase;
                Game.Instance.Ui.txtScore.Change(origin, num2);
            }
        }
    }
    public void TestFly()
    {
        Fly(100, 1);

    }
}
