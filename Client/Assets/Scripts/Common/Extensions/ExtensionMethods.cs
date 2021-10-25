using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class ExtensionMethods
{
    public static bool SavelyAdd<K, V>(this Dictionary<K, V> self, K key, V value, bool replace = false)
    {
        if (replace)
        {
            self[key] = value;
            return true;
        }
        if (self.ContainsKey(key))
        {
            return false;
        }
        else
        {
            self.Add(key, value);
        }
        return false;
    }
    public static void SavelyRemove<K, V>(this Dictionary<K, V> self, K key)
    {
        if (self.ContainsKey(key))
        {
            self.Remove(key);
        }
    }

    public static bool IsNullOrEmpty(this ICollection self)
    {
        return self == null || self.Count == 0;
    }
    public static bool IsNullOrEmpty(this string self)
    {
        return string.IsNullOrEmpty(self);
    }
    public static bool Proximate(this float self, float other)
    {
        float diff = self - other;
        return diff < float.Epsilon && diff > -float.Epsilon;
    }
    public static T GetOrAddComponent<T>(this GameObject self) where T : Component
    {
        if (self == null)
        {
            return null;
        }
        T component = self.GetComponent<T>();
        if (!component)
        {
            component = self.AddComponent<T>();
        }
        return component;
    }
    public static T GetOrAddComponent<T>(this MonoBehaviour self) where T : Component
    {
        if (self == null)
        {
            return null;
        }
        return self.gameObject.GetOrAddComponent<T>();
    }
}
