using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class EditorTools
{
    [MenuItem("Test/StartDialog")]
    public static void StartDialog()
    {
        DialogManager.Instance.StartDialog(100001);
    }
}
