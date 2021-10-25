using UnityEngine;

namespace SWLJ
{
    public class MonoSingleton<T> : MonoBehaviour,ISingleton where T : MonoBehaviour
    {
        private static T _instance;
        private static readonly object _instanceLock = new object();
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_instanceLock)
                    {
                        _instance = new GameObject(typeof(T).Name).AddComponent<T>();
                        _instance.transform.SetParent(MonoSingletonRoot.Instance.transform);
                    }
                }
                return _instance;
            }
        }
        protected bool _inited = false;
        public void Init()
        {
            if (!_inited)
            {
                _inited = true;
                OnInit();
            }
        }
        protected virtual void OnInit()
        {

        }
    }
}