using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SWLJ
{
    public class TableSrc
    {

    }
    public class TableManager : Singleton<TableManager>
    {
        private const string JSON_PATH = "JsonConfigs/";

        private Dictionary<Type, Dictionary<uint, TableSrc>> _allTabledict = new Dictionary<Type, Dictionary<uint, TableSrc>>();

        public T Get<T>(uint id) where T : TableSrc
        {
            Dictionary<uint, TableSrc> singleTableDict = null;
            _allTabledict.TryGetValue(typeof(T), out singleTableDict);
            if(singleTableDict == null)
            {
                singleTableDict = GetSingleTableSrc<T>(typeof(T).Name);
                if(singleTableDict.IsNullOrEmpty())
                {
                    return null;
                }
                _allTabledict.Add(typeof(T), singleTableDict);
            }
            TableSrc result = null;
            singleTableDict.TryGetValue(id, out result);
            return result as T;
        }

        public Dictionary<uint, TableSrc> GetSingleTableSrc<T>(string name) where T : TableSrc
        {
            try
            {
                string fullResPath = JSON_PATH + name;
                TextAsset jsonText = Resources.Load<TextAsset>(fullResPath);
                if (jsonText == null)
                {
                    return null;
                }
                var metaDatas = LitJson.JsonMapper.ToObject<Dictionary<string, T>>(jsonText.text);
                if (metaDatas.IsNullOrEmpty())
                {
                    return null;
                }
                //先判空，不空了再实例化，节省没必要的开销
                Dictionary<uint, TableSrc> result = new Dictionary<uint, TableSrc>();
                foreach (var pair in metaDatas)
                {
                    uint key = uint.Parse(pair.Key);
                    result.Add(key,pair.Value);
                }
                return result;
            }
            catch (Exception e)
            {
                LogUtil.LogError(e.Message);
                throw;
            }
        }
    }
}
