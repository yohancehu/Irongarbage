using SWLJ;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DialogTriggerEventType
{
    None = 0,
    SkipToDialog = 1,
    MiniGame = 2,
}

public class DialogManager : Singleton<DialogManager>
{
    private DialogView _dialogView;

    public void StartDialog(uint id)
    {
        if(_dialogView == null)
        {
            UIManager.Instance.Open(UIType.DialogView);
            _dialogView = UIManager.Instance.GetUI<DialogView>();
        }
        _dialogView.StartDialog(id);
    }
    public void DestroyView()
    {
        UIManager.Instance.Close(UIType.DialogView);
        _dialogView = null;
    }



    public void DialogTriggerEvent(DialogTriggerEventType type, string param)
    {
        switch (type)
        {
            case DialogTriggerEventType.SkipToDialog:
                StartDialog(uint.Parse(param));
                break;
            case DialogTriggerEventType.MiniGame:
                DestroyView();
                Debug.Log($"进入了小游戏 {param}");
                break;
            default:
                break;
        }
    }
}
