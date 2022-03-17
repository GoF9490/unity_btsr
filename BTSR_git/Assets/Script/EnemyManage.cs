using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class EnemyManage : MonoBehaviourPunCallbacks, IPunObservable
{
    PhotonView _pv;
    //PlayerStatus _ps;
    public Vector3 _curPos;
    public Vector3 _curRot;
    //public playerAction _curAct;

    private void Start()
    {
        _pv = this.gameObject.GetComponent<PhotonView>();
        //_ps = this.gameObject.GetComponent<PlayerStatus>();
    }

    private void Update()
    {
        if (_pv.IsMine)
        {
            return;
        }
        else if ((transform.position - _curPos).sqrMagnitude >= 20) transform.position = _curPos;
        else
        {
            transform.position = Vector3.Lerp(transform.position, _curPos, Time.deltaTime * 10);
            transform.eulerAngles = _curRot;
            //_ps._action = _curAct;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.eulerAngles);
            //stream.SendNext(_ps._action);
        }
        else
        {
            _curPos = (Vector3)stream.ReceiveNext();
            _curRot = (Vector3)stream.ReceiveNext();
            //_curAct = (playerAction)stream.ReceiveNext();
        }
    }
}
