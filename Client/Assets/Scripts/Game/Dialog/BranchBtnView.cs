using TableDefines;
using UnityEngine;
using UnityEngine.UI;

public class BranchBtnView : MonoBehaviour
{
    public Text text;

    private dialogconfig.Branch _data;

    public void SetButton(dialogconfig.Branch branch)
    {
        _data = branch;
        UpdateView();
    }

    private void UpdateView()
    {
        if(_data == null)
        {
            return;
        }
        text.text = _data.description;
    }

    public void OnClick()
    {
        if(_data == null)
        {
            return;
        }
        DialogManager.Instance.DialogTriggerEvent((DialogTriggerEventType)_data.triggerType, _data.triggerParam);
    }

    public void Dispose()
    {
        Destroy(gameObject);
    }
}
