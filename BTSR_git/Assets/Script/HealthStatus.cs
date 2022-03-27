using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class HealthStatus : MonoBehaviourPun
{
    PhotonView _pv;

    [SerializeField] int _maxHP = 1;
    [SerializeField] int _hp = 1;

    [SerializeField] bool _dead = false;
    //[SerializeField] bool _player = false;
    [SerializeField] bool _enemy = false;

    private void Start()
    {
        _pv = this.gameObject.GetComponent<PhotonView>();
        _hp = _maxHP;
    }

    public void ReduceHP(int dmg)
    {
        if (PhotonNetwork.IsMasterClient && _enemy)
        {
            if (!_dead)
            {
                _hp -= dmg;
                _pv.RPC("ChangeHP_RPC", RpcTarget.AllBuffered, _hp);
            }
        }
        else if (_enemy == false && _pv.IsMine)
        {
            if (!_dead)
            {
                _hp -= dmg;
                _pv.RPC("ChangeHP_RPC", RpcTarget.AllBuffered, _hp, GameManager.Instance.GetLocalNum());
            }
        }
    }

    public void SetMaxHP(int chara)
    {
        _maxHP = CharaDB.Instance._charaMap[chara]._charaHP;
        _hp = _maxHP;
    }

    [PunRPC]
    void ChangeHP_RPC(int hp, int localNum = 0)
    {
        this._hp = hp;

        if (_hp <= 0) _dead = true;

        if (_enemy) HPUIMnanger.Instance.HPUI_Enemy(_maxHP, _hp);
        else HPUIMnanger.Instance.HPUI_Player(localNum, _maxHP, _hp);
    }

    
}
