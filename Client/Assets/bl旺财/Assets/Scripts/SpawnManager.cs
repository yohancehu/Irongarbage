using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 说明：横版跳跃游戏，所有敌人在玩家接近时要重新生成，避免玩家慢慢消灭所有怪物，让游戏难度变得太低
public class SpawnManager : MonoBehaviour
{

    public class SpawnData
    {
        public GameObject go;
        public GameObject new_go;
        public Vector3 pos;
        public bool isPlayerNear = false;

        public SpawnData(GameObject go, Vector3 pos)
        {
            this.go = go;
            this.pos = pos;
        }
    }

    public float nearDist = 14;

    List<SpawnData> allData = new List<SpawnData>();

    void Start()
    {
        GameObject[] all = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject go in all)
        {
            go.SetActive(false);
            SpawnData sd = new SpawnData(go, go.transform.position);
            allData.Add(sd);
        }
    }


    void Update()
    {
        foreach (SpawnData sd in allData)
        {
            float dist = Vector3.Distance(GameMode.Instance.player.position, sd.go.transform.position);
            if (sd.isPlayerNear)
            {
                if (dist > nearDist+1)
                {
                    sd.isPlayerNear = false;
                    if (sd.new_go != null)
                    {
                        Destroy(sd.new_go);
                    }
                }
            }
            else
            {
                if (dist < nearDist-1)
                {
                    sd.isPlayerNear = true;
                    sd.new_go = Instantiate(sd.go, sd.go.transform.position, sd.go.transform.rotation);
                    sd.new_go.transform.parent = sd.go.transform.parent;
                    sd.new_go.SetActive(true);
                }
            }
        }
        
    }
}
