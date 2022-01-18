using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    public Transform Target1;
    public Transform Target2;
    public float smoothing;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void LateUpdate()
    {
        if (Target1 != null || Target2 != null)
        {
            Vector3 targetPos = 0.5f*(Target1.position+Target2.position);
            if (transform.position != targetPos)
            {
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
