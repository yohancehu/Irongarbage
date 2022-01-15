using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnFall : MonoBehaviour
{
    void Update()
    {
        FallDie();
    }

    private void FallDie()
    {
        if (transform.position.y < -20)
        {
            Destroy(gameObject);
        }
    }
}
