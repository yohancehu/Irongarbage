using SWLJ;
using System.Collections;
using System.Collections.Generic;
using TableDefines;
using UnityEngine;
using UnityEngine.UI;

public class DialogView : MonoBehaviour
{
    public Text ContentText;
    public Text NameText;

    private dialogconfig _currentData;

    public void StartDialog(uint id)
    {
        ShowDialog(id);
    }

    private void ShowDialog(uint id)
    {
        _currentData = TableManager.Instance.Get<dialogconfig>(id);
        if (_currentData == null)
        {
            Debug.LogError($"找不到对话{id}");
            return;
        }
        ContentText.text = _currentData.content;
        var unit = TableManager.Instance.Get<unitconfig>((uint)_currentData.speakerId);
        NameText.text = unit.name;
    }

    public void OnClickBgButton()
    {
        if(_currentData == null || _currentData.nextId == 0)
        {
            DialogManager.Instance.DestroyView();
            return;
        }
        ShowDialog((uint)_currentData.nextId);
    }
}
