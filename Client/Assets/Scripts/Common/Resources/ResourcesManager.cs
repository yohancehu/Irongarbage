using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SWLJ
{
    public class ResourcesManager : Singleton<ResourcesManager>
    {
        protected override void OnInit()
        {
            
        }

        public T Load<T>(string path) where T : Object
        {
            return Resources.Load<T>(path);
        }
    }
}
