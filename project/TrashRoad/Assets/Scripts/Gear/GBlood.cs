using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
namespace Gear.Runtime.UI
{
    /// <summary>
    /// 有减血跟随效果的血条，加血不跟随
    /// </summary>
    public class GBlood : GBase
    {

        public RectTransform _FrontRect;

        public RectTransform _BackRect;

        [SerializeField]
        private bool _UseFilled = false;
        [SerializeField]
        private float _Duration = .3f;
        [SerializeField]
        private float _Time = .5f;

        private float _Value = 1;
        private float _MaxSize;
        private float _InvokeValue;

        protected override void Awake()
        {
            base.Awake();

            _MaxSize = RectTrans.sizeDelta.x;
            _Value = _FrontRect.sizeDelta.x / _MaxSize;
            _FrontRect.anchorMin = _FrontRect.anchorMax = _FrontRect.pivot = _BackRect.anchorMin = _BackRect.anchorMax = _BackRect.pivot = Vector2.up * .5f;
            _FrontRect.anchoredPosition = _BackRect.anchoredPosition = Vector2.zero;
            _FrontRect.sizeDelta = _BackRect.sizeDelta = RectTrans.sizeDelta;
            SetValue(_Value);
        }

        public void SetParam(float duration, float time)//主要是为程序提供lua中修改参数的方法
        {
            _Duration = duration;
            _Time = time;
        }
        public void SetValue(float value)
        {
            value = Mathf.Clamp(value, 0f, 1f);
            if (_Value == value) return;

            _Value = value;
            if (float.IsNaN(_Value))
                _Value = 0f;

            if (_UseFilled)
            {
                _FrontRect.GetComponent<Image>().DOFillAmount(_Value, 0.3f);
                _BackRect.GetComponent<Image>().DOFillAmount(_Value, _Duration).SetDelay(0.5f);
            }
            else
            {
                _FrontRect.DOScaleX(_Value, 0.3f);
                _BackRect.DOScaleX(_Value, _Duration).SetDelay(0.5f);
            }
        }
    }

}