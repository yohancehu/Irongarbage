using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public enum PlayerControlSln
{
    None,
    Player1,
    Player2
}

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    CharacterController2D cc;

    Animator anim;

    AudioSource audioSource;
    public AudioClip soundJump;

    float move;     // 左右输入
    bool jump;      // 跳跃

    public float speed = 5; // 移动速度

    Transform groundCheck;

    bool dead = false;

    bool freezeInput = false;
    public PlayerControlSln pcs;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        cc = GetComponent<CharacterController2D>();
        groundCheck = transform.Find("GroundCheck");
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (dead)
        {
            rigid.simulated = false;
            anim.enabled = false;
        }
        else
        {
            if(!freezeInput)
            {
                switch (pcs)
                {
                    case PlayerControlSln.Player1:

                        move = Input.GetAxis("Horizontal");
                        jump = Input.GetButton("Jump");
                        break;
                    case PlayerControlSln.Player2:

                        move = Input.GetAxis("Horizontal2");
                        jump = Input.GetButton("Jump2");
                        break;  
                }
            }
            else
            {
                move = 0;
                jump = false;
            }

            SetAnim();
            FallDie();
        }
    }

    void SetAnim()
    {
        if (cc.isGrounded)
        {
            anim.SetBool("jump_up", false);
            anim.SetBool("jump_down", false);
            anim.SetFloat("speed", Mathf.Abs(move));
        }
        else
        {
            if (rigid.velocity.y > 0)
            {
                anim.SetBool("jump_up", true);
                anim.SetBool("jump_down", false);
            }
            else
            {
                anim.SetBool("jump_up", false);
                anim.SetBool("jump_down", true);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!dead)
        {
            cc.Move(move * speed * Time.fixedDeltaTime, jump);
        }
    }

    private void FallDie()
    {
        if (dead)
        {
            return;
        }
        if (transform.position.y < -8)
        {
            GameObject go_vcam = GameObject.FindGameObjectWithTag("VCam");
            CinemachineVirtualCamera vcam = go_vcam.GetComponent<CinemachineVirtualCamera>();
            vcam.Follow = null;
        }
        if (transform.position.y < -10)
        {
            dead = true;
            BGMusic.Instance.PlayDeadMusic();
            Invoke("ResetGame", 3);
        }
    }

    void ResetGame()
    {
        SceneManager.LoadScene(0);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Box"))
        {
            if (collision.transform.position.y >= transform.position.y + 0.7f)
            {
                ItemBox box = collision.transform.GetComponent<ItemBox>();
                if (box)
                {
                    box.OnHeadbutted();
                }
            }
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            Item item = collision.transform.GetComponent<Item>();
            if (item)
            {
                item.OnItemGot(this);
            }
        }

        // 被敌人Enemy碰到
        if ((1<<collision.gameObject.layer & LayerMask.GetMask("Enemy", "Boss")) != 0)
        {
            // 如果在空中，要先检测是不是脚底踩到敌人
            if (!cc.isGrounded)
            {
                float w = 0.3f;
                if (transform.localScale.x > 1.1f)
                {
                    w = 0.5f;
                }
                Collider2D[] colliders = Physics2D.OverlapBoxAll(groundCheck.position, new Vector2(w, 0.2f), 0, LayerMask.GetMask("Enemy", "Boss"));
                foreach (Collider2D c in colliders)
                {
                    RoleDie rd = c.GetComponent<RoleDie>();
                    if (rd != null)
                    {
                        rd.Die(c.transform);
                        // 反弹
                        rigid.velocity = new Vector2(rigid.velocity.x, 0);
                        rigid.AddForce(new Vector2(0, 300));
                    }
                }
                if (colliders.Length > 0)
                {
                    return;
                }
            }

            // 运行到这里说明没踩到敌人，碰撞死亡
            dead = true;
            Invoke("ResetGame", 3);
            BGMusic.Instance.PlayDeadMusic();
        }
    }

    public void EatMushroom()
    {
        transform.localScale = new Vector3(Mathf.Sign(transform.localScale.x), 1, 1) * 1.3f;
        cc.jumpForce = 560;
    }

    public void FreezeInput(bool b)
    {
        freezeInput = b;

    }
}
