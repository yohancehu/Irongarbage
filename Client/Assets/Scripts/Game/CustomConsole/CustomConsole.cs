using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomConsole : MonoBehaviour
{
    public InputField InputField;
    public GameObject HideRoot;
    public Text HideBtnText;

    public void StartDialog()
    {
        try
        {
            if(uint.TryParse(InputField.text, out uint id))
            {
                DialogManager.Instance.StartDialog(id);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.Message);
            throw;
        }
    }

    public void SwitchHideState()
    {
        bool active = HideRoot.activeSelf;
        HideRoot.SetActive(!active);
        HideBtnText.text = active ? "ÏÔÊ¾" : "Òþ²Ø";
    }
}
