using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;

    float face;

    public Vector2 jumpSpeed = new Vector2(3, 5);

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        face = transform.localScale.x;
        StartCoroutine(FrogAI());
    }

    IEnumerator FrogAI()
    {
        yield return null;
        while(true)
        {
            // Idle
            yield return new WaitForSeconds(1);

            // Jump
            anim.SetTrigger("jump");
            rigid.velocity = (face * -transform.right + transform.up) * jumpSpeed;
            yield return new WaitForSeconds(2.5f);
        }
    }

}
