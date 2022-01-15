using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPosition : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        Transform player = GameMode.Instance.player;
        if (player.position.x >= transform.position.x)
        {
            BGMusic.Instance.PlayBossMusic();
            gameObject.SetActive(false);
        }
    }
}
