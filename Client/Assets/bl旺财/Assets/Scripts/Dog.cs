using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;

    float face;

    public float speed = 6;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        face = -transform.localScale.x;
    }

    private void DebugLine(Vector3 pos, Vector3 dir, float dist, bool hit)
    {
        Color color = Color.white;
        if (hit)
        {
            color = Color.red;
        }
        Debug.DrawLine(transform.position, transform.position + (dir.normalized * dist), color);
    }

    private void Update()
    {
        float s = Mathf.Abs(transform.localScale.x);
        bool forward_down = Physics2D.Raycast(transform.position, new Vector2(-Mathf.Sign(face), -1), 1.4f*s, LayerMask.GetMask("Default"));
        bool forward = Physics2D.Raycast(transform.position, new Vector2(-face, 0), 1f*s, LayerMask.GetMask("Default"));
        bool down = Physics2D.Raycast(transform.position, new Vector2(0, -1), 1.1f*s, LayerMask.GetMask("Default"));

        DebugLine(transform.position, new Vector2(-Mathf.Sign(face), -1), 1.4f*s, forward_down);
        DebugLine(transform.position, new Vector2(-face, 0), 1f*s, forward);
        DebugLine(transform.position, new Vector2(0, -1), 1.1f*s, down);

        bool flip = false;

        if (down)
        {
            if (forward)
            {
                flip = true;
            }
            else if (!forward_down)
            {
                flip = true;
            }
        }
        if (flip)
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
            face = -transform.localScale.x;
        }

        rigid.velocity = new Vector2(-face * speed, rigid.velocity.y);
    }

}
