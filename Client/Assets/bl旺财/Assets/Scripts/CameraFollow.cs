using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject follow;
    private Camera camera;
    public SpriteRenderer background;
    private float startY = 3.5f;
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
        y = Mathf.Max(startY, y);
        camera.transform.position = new Vector3(0, y, -10);

        //background.material.mainTextureOffset = new Vector2(0, y / 500);
    }
}
