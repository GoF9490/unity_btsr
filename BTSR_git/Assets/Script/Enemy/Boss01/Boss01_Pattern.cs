using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/*
 * 패턴1 : 대쉬, 
 */

public class Boss01_Pattern : EnemyPattern
{
    [SerializeField] GameObject[] _attackObj;

    [Header("DashPattern")]
    [SerializeField] GameObject _dashRange;
    [SerializeField] Transform _dashPointObj;
    Vector3 _dashPoint;
    float _dashTime = 0;
    bool _dash = false;


    private void Start()
    {
        _pv = this.gameObject.GetComponent<PhotonView>();
        _tf = this.gameObject.transform;
        _rb = this.gameObject.GetComponent<Rigidbody>();
        _dashPointObj = _tf.Find("DashPoint");
    }

    private void FixedUpdate()
    {
        Cooldown();
        SelectPattern();
        Dash();
    }

    void SelectPattern()
    {
        //if (_pv != null && _pv.IsMine == false) return;

        if (_patternCool <= 0 && _pattern == 0 && _pv.IsMine)
        {
            _pattern = 1;
            Dash1_Start();
        }
    }

    void Dash()
    {
        if (_dash)
        {
            _dashTime += Time.deltaTime * 1.2f;

            _rb.MovePosition(Vector3.Lerp(_tf.position, _dashPoint, _dashTime));

            if (_dashTime >= 1)
            {
                _rb.MovePosition(_dashPoint);
                _dash = false;
                _dashTime = 0;
                //딴곳에 집어넣을거
                _patternCool = 1;
                _pattern = 0;
                _attackObj[0].SetActive(false);
            }
        }
    }

    void Dash1_Start()
    {
        int len = TeamList.Instance._player.Count;
        Vector3 vec = TeamList.Instance._player[Random.Range(0, len)].transform.position - _tf.position;

        float angle = Mathf.Atan2(vec.x, vec.z) * Mathf.Rad2Deg;
        _tf.rotation = Quaternion.AngleAxis(angle, Vector3.up);

        _dashPoint = _dashPointObj.position;
        PhotonNetwork.Instantiate(_dashRange.name, transform.position, transform.rotation)
            .GetComponent<EnemyAttTrigger>().AttTrigger(this.gameObject, 1, "Dash1");
    }

    void Dash1()
    {
        _attackObj[0].SetActive(true);
        _dash = true;
    }
}
