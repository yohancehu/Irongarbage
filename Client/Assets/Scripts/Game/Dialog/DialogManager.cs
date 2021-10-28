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
    private const string DIALOG_VIEW_PATH = "Prefabs/UI/DialogView";

    private DialogView _dialogView;

    public void StartDialog(uint id)
    {
        if(_dialogView == null)
        {
            var gob = Resources.Load<GameObject>(DIALOG_VIEW_PATH);
            gob = GameObject.Instantiate(gob, UIRoot.Instance.transform);
            _dialogView = gob.GetComponent<DialogView>();
        }
        _dialogView.StartDialog(id);
    }
    public void DestroyView()
    {
        GameObject.Destroy(_dialogView.gameObject);
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
                Debug.Log($"������С��Ϸ {param}");
                break;
            default:
                break;
        }
    }
}
