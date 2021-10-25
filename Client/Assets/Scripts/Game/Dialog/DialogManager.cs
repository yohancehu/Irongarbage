using SWLJ;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
