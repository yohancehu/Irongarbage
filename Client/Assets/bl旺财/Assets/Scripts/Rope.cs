using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Rigidbody2D rb1;
    public Rigidbody2D rb2;
    public GameObject ropeDisplay;

    public float force = 1f;
    public float minDistance = 0f;
    public float maxDistance = 10f;

    private void FixedUpdate()
    {
        Vector3 pos1 = rb1.transform.position;
        Vector3 pos2 = rb2.transform.position;
        Vector3 mid = (pos1 + pos2) / 2;

        if (Vector3.Distance(pos1, pos2) < minDistance)
        {
            rb1.AddForce((pos1 - mid).normalized * force);
            rb2.AddForce((pos1 - mid).normalized * force);
        }
        if (Vector3.Distance(pos1, pos2) > maxDistance)
        {
            rb1.AddForce((mid - pos1).normalized * force);
            rb2.AddForce((mid - pos2).normalized * force);
        }
        ropeDisplay.transform.position = mid;
        ropeDisplay.transform.up = rb1.transform.position - rb2.transform.position;
        ropeDisplay.transform.localScale = new Vector3(1, Vector3.Distance(rb1.transform.position, rb2.transform.position), 1);
    }
}
