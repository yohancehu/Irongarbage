using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerRole
{
    _22,
    _33,
    Fox,
}

public class GameMode : MonoBehaviour
{
    public static GameMode Instance { get; set; }

    public Transform player;
    public Transform dogHead;

    public Player obj22;
    public Player obj33;
    public Player objFox;
    public GameObject changeRoleFX;

    int nPlayer = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        player = obj22.transform;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        //if (Input.GetMouseButtonDown(1))
        //{
        //    nPlayer++;
        //    if (nPlayer == 3) nPlayer = 0;
        //    ChangePlayer((PlayerRole)nPlayer);
        //}
    }

    public void ChangePlayer(PlayerRole role)
    {
        Instantiate(changeRoleFX, player.position, Quaternion.identity);
        obj22.gameObject.SetActive(false);
        obj33.gameObject.SetActive(false);
        objFox.gameObject.SetActive(false);

        GameObject go = null;

        switch (role)
        {
            case PlayerRole._22:
                go = obj22.gameObject;
                break;
            case PlayerRole._33:
                go = obj33.gameObject;
                break;
            case PlayerRole.Fox:
                go = objFox.gameObject;
                break;
        }
        go.gameObject.SetActive(true);
        go.transform.position = player.transform.position;
        go.transform.localScale = player.transform.localScale;

        player = go.transform;
        GameObject go_vcam = GameObject.FindGameObjectWithTag("VCam");
        CinemachineVirtualCamera vcam = go_vcam.GetComponent<CinemachineVirtualCamera>();
        vcam.Follow = player;
    }

    public void OnDogClear()
    {
        StartCoroutine(DropDogHead());
    }

    IEnumerator DropDogHead()
    {
        yield return new WaitForSeconds(2);

        GameObject go_vcam = GameObject.FindGameObjectWithTag("VCam");
        CinemachineVirtualCamera vcam = go_vcam.GetComponent<CinemachineVirtualCamera>();
        vcam.Follow = player;

        Player p = player.GetComponent<Player>();
        p.FreezeInput(true);
        p.transform.position = new Vector3(222, -2.6f, 0);

        dogHead.gameObject.SetActive(true);

        yield return new WaitForSeconds(2);
        p.FreezeInput(false);
    }


    ////////// UI ///////////

    public void Choose22()
    {
        GameObject canvas = GameObject.Find("Canvas");
        canvas.transform.Find("Panel1").gameObject.SetActive(false);

        ChangePlayer(PlayerRole._22);
        BGMusic.Instance.PlayNormalMusic();
    }

    public void Choose33()
    {
        GameObject canvas = GameObject.Find("Canvas");
        canvas.transform.Find("Panel1").gameObject.SetActive(false);
        ChangePlayer(PlayerRole._33);
        BGMusic.Instance.PlayNormalMusic();
    }

    public void FinishGame()
    {
        GameMode.Instance.ChangePlayer(PlayerRole.Fox);
        BGMusic.Instance.PlayCongratulationMusic();

        Invoke("FinishUI", 6.5f);
    }

    public void FinishUI()
    {
        GameObject canvas = GameObject.Find("Canvas");
        canvas.transform.Find("Panel2").gameObject.SetActive(true);
        BGMusic.Instance.PlayNormalMusic();
    }

}
