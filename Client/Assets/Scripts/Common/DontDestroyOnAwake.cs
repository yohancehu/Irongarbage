using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnAwake : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
