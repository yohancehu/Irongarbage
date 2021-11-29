using UnityEngine;
using System.Collections;
 
public class LineRender: MonoBehaviour {
	private GameObject clone;
	private LineRenderer line;
	int index;
	//带有LineRender物体
	public GameObject target;
    // private GameObject[] Objs;暂时没有作用
	void Start () 
    {
	}
	// Update is called once per frame
	void Update () 
    {

		if (Input.GetMouseButtonDown(0))
        {
			//实例化对象
		    clone=(GameObject)Instantiate(target,target.transform.position,Quaternion.identity);
            //实例化对象编组
            // Objs[i]=clone;
            // i++;
			//获得该物体上的LineRender组件
			line=clone.GetComponent<LineRenderer>();
			//设置起始和结束的颜色
			line.startColor = Color.red;
            line.endColor = Color.blue;
			//设置起始和结束的宽度
			line.startWidth = 3.0f;
        	line.endWidth = 3.0f;
			//计数
            index = 1;
 			line.SetPosition(index-1,Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,3)));
		}
		if(Input.GetMouseButton(0))
		{
			//每一帧检测，按下鼠标的时间越长，计数越多
            if (index<999)//防止超出范围（感觉后续需要改进）
            {
            	index++;
			    //设置顶点数
			    line.positionCount = index;
			    //设置顶点位置(顶点的索引，将鼠标点击的屏幕坐标转换为世界坐标)
			    line.SetPosition(index-1,Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,3)));
                //     Object.Destroy(Objs[i])
            }
		}
 
	}
}