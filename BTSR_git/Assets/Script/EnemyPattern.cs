using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnemyPattern : MonoBehaviourPun
{
    protected PhotonView _pv;
    protected Transform _tf;
    protected Rigidbody _rb;

    protected bool _attack = false;
    protected bool _delay = false;

    protected int _pattern = 0;
    [SerializeField ]protected float _patternCool = 0;

    protected void Cooldown()
    {
        if (_patternCool >= 0)
        {
            _patternCool -= Time.deltaTime;
        }
    }
}
