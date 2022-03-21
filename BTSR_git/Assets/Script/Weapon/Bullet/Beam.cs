using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Photon.Pun; // 포톤 트랜스폼 뷰 동기화가 스케일 동기화가 제대로 안됨, 다른 방법.

public class Beam : MonoBehaviour//Pun
{
    private BulletStat _bulletStat;

    [SerializeField] private GameObject _beam;
    [SerializeField] private GameObject _ScaleDistance;
    [SerializeField] private GameObject _hitEff;
    [SerializeField] LayerMask _layer;
    // private PhotonView _pv;

    [SerializeField] private float _beamSize = 1;
    //[SerializeField] private GameObject _beamEff;  //  use?

    private void Start()
    {
        _bulletStat = this.gameObject.GetComponent<BulletStat>();
       // _pv = this.gameObject.GetComponent<PhotonView>();

        Shoot();
    }

    private void OnDisable()
    {
        transform.localScale = new Vector3(_beamSize, _beamSize, _beamSize);
    }

    void Shoot()
    {
        /* 타겟의 위치를 잡고서 그 거리만큼 이펙트 길이를 잡는 방식, 사거리 무한이라 폐기.
        if (ps._target != null)
        {
            transform.LookAt(ps._target.transform);

            Vector3 vec = transform.position - ps._target.transform.position;

            _ScaleDistance.transform.localScale = new Vector3(1, 1, Vector3.Magnitude(vec));

            _hitEff.SetActive(true);
            _hitEff.transform.position = ps._target.transform.position;

            Destroy(this.gameObject, 1.5f);
        }

        else */
        {
            RaycastHit hit;

            //Debug.DrawRay(transform.position, transform.forward, Color.red);

            if (Physics.Raycast(transform.position, transform.forward, out hit, _bulletStat.GetRange(), _layer, QueryTriggerInteraction.Ignore))
            {
                CheckHit(hit.collider.gameObject);
                _ScaleDistance.transform.localScale = new Vector3(_beamSize, _beamSize, hit.distance);

                _hitEff.SetActive(true);
                _hitEff.transform.position = hit.point;
            }

            else
            {
                _ScaleDistance.transform.localScale = new Vector3(_beamSize, _beamSize, _bulletStat.GetRange());
            }
        }
    }

    public void CheckHit(GameObject hit)
    {
        if (hit.GetComponent<HitPoint>())
        {
            hit.GetComponent<HitPoint>().HitCheck(_bulletStat.GetDmg());
        }
    }
}
