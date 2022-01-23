using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject follow;
    private Camera camera;
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (!follow)
        {
            return;
        }
        float y = Mathf.Lerp(camera.transform.position.y, follow.transform.position.y, Time.deltaTime);
        y = Mathf.Max(3.5f, y);
        camera.transform.position = new Vector3(0, y, -10);
    }
}
