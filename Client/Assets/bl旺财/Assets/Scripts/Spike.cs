using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.CompareTag("Player"))
        {
            GameObject prefab = Resources.Load<GameObject>("Prefabs/Lose");
            GameObject obj = Instantiate(prefab, UIRoot.Instance.transform);
            LoseUI ui = obj.GetComponent<LoseUI>();
            ui.SetText("你被扎死了。");
        }
    }
}
