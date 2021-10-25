
using UnityEngine;

public class UIRoot : MonoBehaviour
{
    public static UIRoot Instance;

    public uint id;

    private void Awake()
    {
        Instance = this;
    }

    public void StartDialog()
    {
        DialogManager.Instance.StartDialog(id);
    }
}
