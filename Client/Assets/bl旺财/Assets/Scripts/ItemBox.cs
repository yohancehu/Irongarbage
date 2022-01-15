using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public GameObject prefabItem;
    public Sprite closedSprite;

    bool closed = false;

    void Start()
    {
    }

    public void OnHeadbutted()
    {
        if (!closed)
        {
            StartCoroutine(OpenAndDrop());
        }
    }

    IEnumerator OpenAndDrop()
    {
        closed = true;
        GetComponent<SpriteRenderer>().sprite = closedSprite;

        for (int i=0; i<6; i++)
        {
            transform.Translate(new Vector3(0, 0.05f, 0));
            yield return null;
        }
        for (int i=0; i<2; i++)
        {
            transform.Translate(new Vector3(0, -0.15f, 0));
            yield return null;
        }

        if (prefabItem)
        {
            GameObject obj = Instantiate(prefabItem, transform.position, Quaternion.identity);
            if (obj.GetComponent<ItemMove>() != null)
            {
                obj.GetComponent<ItemMove>().enabled = false;
                obj.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
            for (int i=0; i<12; i++)
            {
                obj.transform.Translate(0, 0.1f, 0);
                yield return null;
            }
            obj.GetComponent<ItemMove>().enabled = true;
            obj.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
