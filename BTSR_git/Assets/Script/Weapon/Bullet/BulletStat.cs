using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BulletStat : MonoBehaviourPun
{
    [SerializeField] BulletContainer _bc;
    [SerializeField] private int _dmg = 0;
    [SerializeField] private float _range = 0; // use?

    Vector3 _startPoint;
    Vector3 _endPoint;

    public void SetBC(BulletContainer bc)
    {
        this._bc = bc;
    }

    public void SetPoint(Vector3 startPoint, Vector3 endPoint)
    {
        this._startPoint = startPoint;
        this._endPoint = endPoint;
    }

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
