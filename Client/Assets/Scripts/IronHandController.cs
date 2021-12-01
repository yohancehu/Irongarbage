using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IronHandController : MonoBehaviour
{
    [SerializeField]ParticleSystem _effect;
    public void Update()
    {   
        transform.position = Input.mousePosition;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);

        if(Input.GetMouseButton(0))
        {
            _effect?.Play();
        }
    }
}
