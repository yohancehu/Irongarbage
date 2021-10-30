
using UnityEngine;

public class UIRoot : MonoBehaviour
{
    public static UIRoot Instance;

    public Transform BackgoundRoot;
    public Transform DialogRoot;
    public Transform WindwoRoot;
    public Transform TipsRoot;
    public Transform LoadingRoot;
    

    private void Awake()
    {
        Instance = this;
    }

    public void SetParent(UILayer layer,Transform child)
    {
        if(child == null)
        {
            return;
        }
        switch (layer)
        {
            case UILayer.Background:
                child.SetParent(BackgoundRoot);
                break;
            case UILayer.Dialog:
                child.SetParent(DialogRoot);
                break;
            case UILayer.Window:
                child.SetParent(WindwoRoot);
                break;
            case UILayer.Tips:
                child.SetParent(TipsRoot);
                break;
            case UILayer.Loading:
                child.SetParent(LoadingRoot);
                break;
            default:
                break;
        }
        child.localPosition = new Vector3(0,0,0);
        child.localScale = new Vector3(1,1,1);
        child.localRotation = new Quaternion(0,0,0,0);
    }
}
