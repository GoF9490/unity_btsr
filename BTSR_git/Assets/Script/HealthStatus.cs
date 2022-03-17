using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class HealthStatus : MonoBehaviourPun
{
    PhotonView _pv;

    [SerializeField] int _maxHP = 0;
    int _hp = 0;

    [SerializeField] bool _dead = false;

    private void Start()
    {
        _pv = this.gameObject.GetComponent<PhotonView>();
        _hp = _maxHP;
    }

    public void ReduceHP(int dmg)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (!_dead)
            {
                _hp -= dmg;

                _pv.RPC("ChangeHP_RPC", RpcTarget.AllBuffered, _hp);
            }
        }
    }

    [PunRPC]
    void ChangeHP_RPC(int hp)
    {
        this._hp = hp;

        if (_hp <= 0) _dead = true;

        HPUIMnanger.Instance.ChangeEnemyHP(_maxHP, _hp);
    }

    
}
