using SWLJ;
using System.Collections;
using System.Collections.Generic;
using TableDefines;
using UnityEngine;
using UnityEngine.UI;

public class DialogView : UIViewBase
{
    public Button BgButton;
    public Text ContentText;
    public Text NameText;
    public GameObject BranchView;
    public GameObject BranchBtnPrefab;
    public Transform BranchRoot;

    private dialogconfig _currentData;
    private List<BranchBtnView> _branchBtns = new List<BranchBtnView>();

    public override void OnCreate(params object[] args)
    {
        base.OnCreate(args);
        ContentText = transform.Find("Frame/ContentText").GetComponent<Text>();
        NameText = transform.Find("Frame/NameText").GetComponent<Text>();
        BranchBtnPrefab = transform.Find("BranchView/BranchBtnPrefab").gameObject;
        BranchView = transform.Find("BranchView").gameObject;
        BranchRoot = transform.Find("BranchView/BranchRoot");
        BgButton = transform.Find("Bg").GetComponent<Button>();

        BgButton.onClick.AddListener(OnClickBgButton);
    }

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
        TryShowBranchView();
    }

    public void OnClickBgButton()
    {
        if(_currentData == null || _currentData.nextId == 0)
        {
            DialogManager.Instance.DestroyView();
            return;
        }
        if(_currentData.triggerType != 0)
        {
            DialogManager.Instance.DialogTriggerEvent((DialogTriggerEventType)_currentData.triggerType, _currentData.triggerParam);
        }
        ShowDialog((uint)_currentData.nextId);
    }


    public void TryShowBranchView()
    {
        if(_currentData.branch == null || _currentData.branch.Count == 0)
        {
            foreach (var btn in _branchBtns)
            {
                if (btn != null)
                {
                    btn.Dispose();
                }
            }
            _branchBtns.Clear();
            BranchView.SetActive(false);
            return;
        }

        BranchView.SetActive(true);
        foreach (var branch in _currentData.branch)
        {
            GameObject gob = Instantiate(BranchBtnPrefab, BranchRoot);
            gob.SetActive(true);
            BranchBtnView view = gob.GetComponent<BranchBtnView>();
            view.SetButton(branch);
            _branchBtns.Add(view);
        }
    }
}
