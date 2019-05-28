using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
namespace Gear.Runtime.UI
{
    public class GBase : UIBehaviour, IButtonClickCallBack, IData
    {
        public object Data;
        [HideInInspector]
        private Transform _Transform;
        private RectTransform _RectTransform;

        public Transform Trans
        {
            get
            {
                if (_Transform == null)
                    _Transform = transform;
                return _Transform;
            }
        }

        public RectTransform RectTrans
        {
            get
            {
                if (_RectTransform == null)
                    _RectTransform = Trans as RectTransform;
                if (_RectTransform == null)
                    _RectTransform = gameObject.AddComponent<RectTransform>();
                return _RectTransform;
            }
        }

        protected override void Awake()
        {

        }
        protected override void Start()
        {
            // to be override
        }
        protected override void OnEnable()
        {
            // to be override 
        }
        protected override void OnDisable()
        {
            //to be override
        }
        protected override void OnDestroy()
        {
            //to be override
        }

        public virtual void SetData(object data)
        {
            Data = data;
        }

        public virtual void OnButtonClickHandler(GameObject obj)
        {

        }

        public virtual void OnButtonSelectHandler(GameObject value)
        {

        }
    }
}
