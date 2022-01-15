using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleDie : MonoBehaviour
{
    public GameObject prefabDeadFX;

    void Start()
    {
    }

    public virtual void Die(Transform trans)
    {
        Instantiate(prefabDeadFX, trans.position, Quaternion.identity);
        Destroy(gameObject);
    }


}
