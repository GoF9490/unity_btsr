using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

/*
 * 다른 모든 무기에 들어가는 범용 컴포넌트
 * 플레이어블에게서 일부 변수를 받아옴
 * 다른 리모트 무기들에게 punrpc로 공격 이펙트를 활성화 해주는 역할을 수행해야함
 * 
 *      // 오브젝트 풀링 형식 시험에 사용해본 코드, 버그있고, 과정이 불편함. 다른방식으로 사용하거나 걍 일단 생성으로.
 *      GameObject attack = _muzzle.transform.GetChild(0).gameObject;
        attack.GetComponent<BulletStat>().SetDmg(_wpDmg);
        attack.GetComponent<BulletStat>()._range = _wpRan;
        attack.GetComponent<BulletStat>()._parent = _muzzle;
        attack.transform.parent = null;
        attack.SetActive(true);


        if (_pv.IsMine)
        {
            GameObject contain = PhotonNetwork.Instantiate(_bulletContain.name, new Vector3(0, 0, 0), Quaternion.identity);
            _bulletContain = contain;
        }
 */

public class WeaponSet : MonoBehaviourPun
{
    public PlayerStatus _ps;
    PhotonView _pv;

    [SerializeField] GameObject _bulletContain;
    [SerializeField] GameObject _shot;
    [SerializeField] int _magazine = 0;
    [SerializeField] int _wpDmg = 0;
    [SerializeField] float _wpRan = 0;

    [SerializeField] private Transform _muzzle;

    private void Start()
    {
        _pv = this.photonView;
        _muzzle = transform.Find("Muzzle").Find("Muzzle");
        GameObject BulletContain = Instantiate(_bulletContain, new Vector3(0, 0, 0), Quaternion.identity);
        _bulletContain = BulletContain;
    }

    private void FixedUpdate()
    {
        //_magazine = _muzzle.childCount;  // 오브젝트풀링형식 할때 사용할듯.
    }

    public void SetWeaponStat(int wpDmg, float wpRan)
    {
        this._wpDmg = wpDmg;
        this._wpRan = wpRan;
    }

    public void Attack(Vector3 vec, bool hit)
    {

    }

    public void Attack()
    {
        /* 생산방식, 오브젝트풀 방식으로 연구해볼것.
         * PhotonNetwork.Instantiate(_shot.name, _muzzle.position, _ps.transform.rotation)
            .GetComponent<PhotonView>().RPC("SetStat", RpcTarget.AllBuffered, _wpDmg, _wpRan);
         */
    }

    /* 안쓸듯?
    [PunRPC]
    void AttackRPC() // rpc? 아니면 photonnetwork.Instantiate?
    {
        GameObject shot = Instantiate(_shot, _muzzle.position, _ps.transform.rotation);
        // 방법 연구해
        //shot.GetComponent<BulletStat>().SetDmg(_wpDmg);
        //shot.GetComponent<BulletStat>()._range = _wpRan;
    }
     */
}
