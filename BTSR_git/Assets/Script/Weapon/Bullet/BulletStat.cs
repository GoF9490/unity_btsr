using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BulletStat : MonoBehaviourPun
{
    [SerializeField] BulletContainer _bc;
    [SerializeField] private int _dmg = 0;
    [SerializeField] private float _range = 0; // use?

    public bool _hit = false;
    public Vector3 _startPoint;
    public Vector3 _endPoint;

    public void SetBC(BulletContainer bc)
    {
        this._bc = bc;
    }

    public void SetPoint(Vector3 startPoint, Vector3 endPoint, bool hit)
    {
        this._startPoint = startPoint;
        this._endPoint = endPoint;
        this._hit = hit;
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

    public void CallEnqueue()
    {
        _bc.Enqueue(this.gameObject);
    }
}
