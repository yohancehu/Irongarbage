using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IronHandController : MonoBehaviour
{

    Vector3 point;
    GameObject effectGo;

    // Start is called before the first frame update
    void Start()
    {
        effectGo = Resources.Load<GameObject>("Prefabs/hanjieParticle");
    }

    // Update is called once per frame
    public void Update()
    {
        transform.position = Input.mousePosition;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);

        if(Input.GetMouseButton(0))
        {

            point = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 4f);//获得鼠标点击点
            point = Camera.main.ScreenToWorldPoint(point);//从屏幕空间转换到世界空间
            GameObject go = Instantiate(effectGo);//生成特效
            go.transform.position = point;
            Destroy(go, 0.5f);
            Debug.Log("clicl");
        }
    }
}
