using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SWLJ
{
    public class MonoSingletonRoot : MonoBehaviour
    {
        private const string GAMEOBJECT_NAME = "MonoSingletons";
        private static MonoSingletonRoot _instance;
        public static MonoSingletonRoot Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject obj = GameObject.Find(GAMEOBJECT_NAME);
                    if (obj == null)
                    {
                        obj = new GameObject(GAMEOBJECT_NAME);
                    }
                    _instance = obj.GetComponent<MonoSingletonRoot>();
                    if (_instance == null)
                    {
                        _instance = obj.AddComponent<MonoSingletonRoot>();
                    }
                }
                return _instance;
            }
        }
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
