using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

/*
 * 방제로 비밀번호를 대체? 아니면 비밀번호를 따로 체크하는 씬을 구현?
 */

public class NetworkManager : MonoBehaviourPunCallbacks
{
    private readonly string _gameVersion = "0";

    public Text _connectionInfoText;
    public Button _joinButton;


    private void Awake()
    {
        //포톤서버 최적화?
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 30;
    }

    private void Start()
    {
        PhotonNetwork.GameVersion = _gameVersion; // 게임 버전(멀티간 버전 맞추는용도)
        PhotonNetwork.ConnectUsingSettings(); // 마스터 서버 접속문(버전 말고도 여러가지 정보 담을 수 있음)

        _joinButton.interactable = false;
        _connectionInfoText.text = "wait";
    }

    public override void OnConnectedToMaster() // 마스터 서버 접속시 실행
    {
        _joinButton.interactable = true;
        _connectionInfoText.text = "you can";
        //base.OnConnectedToMaster();
    }

    public override void OnDisconnected(DisconnectCause cause) // 접속을 실패한경우, 접속도중 접속이 끊어진 경우 실행
    {
        _joinButton.interactable = false;
        _connectionInfoText.text = $"you can't {cause.ToString()}";

        PhotonNetwork.ConnectUsingSettings(); // 재접속 실행
        //base.OnDisconnected(cause);
    }

    public void Connect()
    {
        _joinButton.interactable = false;

        if (PhotonNetwork.IsConnected) // 한번더 접속상태 체크
        {
            _connectionInfoText.text = "join";
            PhotonNetwork.JoinRandomRoom(); // 조인랜덤룸
            //PhotonNetwork.CreateRoom("Room", new RoomOptions { MaxPlayers = 4 }, null); // 방생성
            //PhotonNetwork.JoinRoom("Room"); // 방참가
        }
        else

        {
            _connectionInfoText.text = "you can't";

            PhotonNetwork.ConnectUsingSettings(); // 재접속 실행
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message) // 랜덤룸 접속 실패시 (ex.방이 없을시)
    {
        _connectionInfoText.text = "create new room";
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 4 });
        //base.OnJoinRandomFailed(returnCode, message);
    }

    public override void OnJoinedRoom() // 룸 접속에 성공시(랜덤이든 뭐든)
    {
        _connectionInfoText.text = "let's game";
        PhotonNetwork.LoadLevel("Test_Lobby"); // 포톤네트워크용 LoadScene. 멀티게임은 LoadScene으로 넘어가면 제각각 개인의 신으로 넘어가진다.
        //base.OnJoinedRoom();
    }
}
