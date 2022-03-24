using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<GameManager>();

            return instance;
        }
    }

    private static GameManager instance;

    [SerializeField] GameObject _camera;
    PhotonView _pv;
    public Transform[] _spawnPositions;
    int _localPlayerIndex = 0;

    [Header("CreateObjects")]
    [SerializeField] GameObject _enemy;
    [SerializeField] GameObject _mousePosition;
    [SerializeField] GameObject _dirCon;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _charaDB;
    [SerializeField] GameObject _weaponDB;

    private void Start()
    {
        _pv = this.gameObject.GetComponent<PhotonView>();
        _localPlayerIndex = PhotonNetwork.LocalPlayer.ActorNumber;
        //CreateEnemy();
        CreatePlayer();
    }

    void CreatePlayer()
    {
        var spawnPosition = _spawnPositions[_localPlayerIndex - 1];

        GameObject mouse = Instantiate(_mousePosition);
        GameObject dircon = Instantiate(_dirCon);
        //Debug.Log("방향 컨트롤러 및 액티브 타겟 세팅"); 

        Instantiate(_charaDB);
        //Debug.Log("캐릭터 데이터베이스 생성");

        Instantiate(_weaponDB);
        //Debug.Log("무기 데이터베이스 생성");

        GameObject player = PhotonNetwork.Instantiate(_player.name, spawnPosition.position, Quaternion.identity);
        //Debug.Log("플레이어 생성");

        player.GetComponent<Player_Awake>().SetMouseDircon(mouse, dircon);
        //Debug.Log("플레이어 어웨이크");

        _camera.GetComponent<Player_Camera>().SetPlayer(player);
        _camera.GetComponent<Player_Camera>()._follow = true;
        //Debug.Log("카메라 세팅");

        TeamList.Instance.SerchTeam();
    }

    void CreateEnemy()
    {
        if (_localPlayerIndex == 1)
        {
            PhotonNetwork.Instantiate(_enemy.name, new Vector3(0, 4, 0), Quaternion.identity);
        }
    }

    public int GetLocalNum()
    {
        return _localPlayerIndex;
    }

    /*
    [PunRPC]
    void PlayerCharaSet()
    {
        int charaNum = PlayerDataCon.Instance.GetCharaNum();
        GameObject charaObj0 = _charaDBObj.transform.GetChild(charaNum - 1).gameObject;
        GameObject charaObj = Instantiate(charaObj0, transform.position, Quaternion.identity);
        charaObj.transform.parent = player.transform;
        charaObj.transform.localPosition = new Vector3(0, 0, 0);
        charaObj.transform.localEulerAngles = new Vector3(0, 0, 0);
        charaObj.SetActive(true);
    }

    [PunRPC]
    void PlayerWpS1Set()
    {
        int wps1Num = PlayerDataCon.Instance.GetCharaNum();
        GameObject wps1Obj0 = _weaponDBObj.transform.GetChild(wps1Num - 1).gameObject;
        GameObject wps1Obj = Instantiate(wps1Obj0, transform.position, Quaternion.identity);
        wps1Obj.transform.parent = player.GetComponentInChildren<EquipPoint>()._handR.transform;
        wps1Obj.transform.localPosition = new Vector3(0, 0, 0);
        wps1Obj.transform.localEulerAngles = new Vector3(0, 0, 0);
        player.GetComponent<PlayerStatus>()._weaponS1 = wps1Obj;
        wps1Obj.SetActive(true);
        //weaponDB.SetActive(false);
    }
    */
}
