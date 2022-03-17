using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BulletStat : MonoBehaviourPun
{
    [SerializeField] private int _dmg = 0;
    [SerializeField] private float _range = 0; // 일단 100고정, 동기화 방법 연구 필요

    public int GetDmg()
    {
        return _dmg;
    }

    public float GetRange()
    {
        return _range;
    }

    [PunRPC]
    public void SetStat(int dmg, float range)
    {
        this._dmg = dmg;
        this._range = range;
    }
}
