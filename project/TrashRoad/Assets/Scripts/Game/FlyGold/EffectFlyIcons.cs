using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EffectFlyIcons : MonoBehaviour
{
    public RollText rt;
    private const int little = 12;
    private const int more = 30;
    [SerializeField]
    private FlyItem item;
    [SerializeField]
    private Transform[] targets;
    [SerializeField]
    private Sprite[] sprites;
    public Queue<FlyItem> queue = new Queue<FlyItem>();
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
    public void Fly(int num, int type = 0)
    {
        this.type = type;
        var target = targets[type];
        var sprite = sprites[type];
        increase = num;
        ManagerAudio.PlaySound("AddGold");
        var realCount = num > 200 ? more : little;
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


    public void Release(FlyItem item)
    {
        queue.Enqueue(item);
        if (item == last)
        {
            if (type == 0)
            {
                int num1 = Profile.Instance.Coin;
                int num2 = num1 + increase;
                Profile.Instance.Coin = num2;
                Game.Instance.Ui.txtCoin.Change(num1, num2);
            }
            else if (type == 1)
            {
                int num1 = Game.Instance.Lvl.Score;
                int num2 = num1 + increase;
                Game.Instance.Lvl.Score = num2;
                Game.Instance.Ui.txtScore.Change(num1, num2);
            }
        }
    }
    public void TestFly()
    {
        Fly(100, 1);

    }
}
