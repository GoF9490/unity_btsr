using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public static LobbyManager Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<LobbyManager>();

            return instance;
        }
    }

    private static LobbyManager instance;

    [SerializeField] PhotonView _pv;
    [SerializeField] Button _readyButton;
    [SerializeField] Text _ButtonText;
    [SerializeField] GameObject[] _pbg = new GameObject[4];

    [SerializeField] int _localPlayerIndex = 0;
    [SerializeField] int _roomPersonnel = 0;
    [SerializeField] int _readyPersonnel = 0;
    [SerializeField] bool[] _playerReady = new bool[4];
    [SerializeField] bool _roomMaster = false;
    [SerializeField] bool _changeScene = false;

    private void Start()
    {
        _pv.RPC("CountPlayer", RpcTarget.AllBuffered);
        _readyButton.interactable = false;
        _localPlayerIndex = PhotonNetwork.LocalPlayer.ActorNumber;
        PhotonNetwork.AutomaticallySyncScene = true;
        //CheckRoomMaster(); 방장이 필요하다면
    }

    private void FixedUpdate()
    {
        //_roomPersonnel = PhotonNetwork.CountOfPlayers; // 뭔가 버그가 많다?
        ReadyCheck();
        GameStart();
    }


    void CheckRoomMaster() // 방장 설정 // 필요하다면
    {
        if (_localPlayerIndex != 1) return;
        _ButtonText.text = "Start";
        _roomMaster = true;
    }

    void GameStart() // 방장의 버튼 활성화 및 게임 씬으로 이동
    {
        //if (_roomPersonnel == _readyPersonnel + 1 && _roomMaster) _readyButton.interactable = true; // 방장이 필요하다면
        if (_roomPersonnel == _readyPersonnel && _readyPersonnel >= 1 && _changeScene == false && _localPlayerIndex == 1)
        {
            _changeScene = true;
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.LoadLevel("Test_Game");
        }
    }

    public void Ready() // 레디 rpc 호출
    {
        _pv.RPC("ReadyRPC", RpcTarget.AllBuffered, _localPlayerIndex);
    }

    void ReadyCheck() // 플레이어 레디 변수에 따른 로비창 변화
    {
        for (int i = 0; i < 4; i++)
        {
            _pbg[i].SetActive(_playerReady[i]);
        }
    }

    public bool GetReady() // 플레이어레디 변수 호출
    {
        return _playerReady[_localPlayerIndex - 1];
    }

    public bool RoomMaster() // 룸마스터 변수 호출
    {
        return _roomMaster;
    }


    [PunRPC]
    void ReadyRPC(int num)
    {
        if (_playerReady[num - 1])
        {
            _playerReady[num - 1] = false;
            _readyPersonnel -= 1;
        }
        else
        {
            _playerReady[num - 1] = true;
            _readyPersonnel += 1;
        }
    }

    [PunRPC]
    void CountPlayer()
    {
        _roomPersonnel += 1;
    }


    /*
    void GetPBG() // 수동으로 문제가 있을겅우 사용?
    {
        for (int i = 0; i < 4; i++)
        {
            _pbg[i] = GameObject.Find("Lobby_InWorld").transform.GetChild(i).gameObject;
        }
    }
    */
}
