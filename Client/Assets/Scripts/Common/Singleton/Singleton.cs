using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SWLJ
{
    public interface ISingleton
    {
        void Init();
    }
    public class Singleton<T> : ISingleton where T : new()
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
                        _instance = new T();
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
