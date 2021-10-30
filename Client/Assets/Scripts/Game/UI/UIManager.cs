using SWLJ;
using System;
using System.Collections;
using System.Collections.Generic;
using TableDefines;
using UnityEngine;

public enum UILayer
{
    Background = 0,
    Dialog = 1,
    Window = 2,
    Tips = 3,
    Loading = 4,
}

public enum UIType
{
    None = 0,
    DialogView = 1,
}

public class UIManager : Singleton<UIManager>
{
    private const string UI_PREFAB_FOLDER = "Prefabs/UI/";
    Dictionary<UIType,UIViewBase> _uiDict = new Dictionary<UIType,UIViewBase>();

    public void Open(UIType uiType, params object[] args)
    {
        if (CheckExist(uiType))
        {
            return;
        }
        uiconfig config = TableManager.Instance.Get<uiconfig>((uint)uiType);
        GameObject prefab = GetUIPrefab(config.prefab);
        GameObject uiGob = GameObject.Instantiate(prefab);
        Type type = Type.GetType(config.className);
        UIViewBase ui = uiGob.AddComponent(type) as UIViewBase;
        if (ui != null)
        {
            ui.OnCreate(args);
            _uiDict.Add(uiType,ui);
            UIRoot.Instance.SetParent((UILayer)config.layer, uiGob.transform);
            ui.OnShow();
        }
    }

    public T GetUI<T>() where T : UIViewBase
    {
        foreach (var value in _uiDict.Values)
        {
            if(value is T)
            {
                return value as T;
            }
        }
        return null;
    }

    public void Close(UIType uiType)
    {
        if (!CheckExist(uiType))
        {
            return;
        }
        UIViewBase ui = _uiDict[uiType];
        GameObject.Destroy(ui.gameObject);
        _uiDict.Remove(uiType);
    }


    private bool CheckExist(UIType uIType)
    {
        return _uiDict.ContainsKey(uIType);
    }
    private GameObject GetUIPrefab(string prefabPath)
    {
        return Resources.Load<GameObject>(UI_PREFAB_FOLDER + prefabPath);
    }
}
