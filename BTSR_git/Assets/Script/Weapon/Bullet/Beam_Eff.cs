using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam_Eff : MonoBehaviour
{
    [SerializeField] GameObject _beam;
    Transform tf;
    float _beamSizeOrigin;
    float _beamSize;
    [SerializeField] float _sizeDownSpeed = 1;

    private void Start()
    {
        tf = this.GetComponent<Transform>();
        _beamSizeOrigin = tf.localScale.x;
        _beamSize = _beamSizeOrigin;
    }

    private void Update()
    {
        BeamEff();
    }

    private void OnDisable()
    {
        if (tf)
        {
            tf.localScale = new Vector3(_beamSizeOrigin, _beamSizeOrigin, _beamSizeOrigin);
            _beamSize = _beamSizeOrigin;
        }
    }

    /* 최후의 수단 (그마저 연구필요)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            _beam.GetComponent<Beam>().CheckHit(other.gameObject);
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
    */

    void BeamEff()
    {
        _beamSize -= Time.deltaTime * _sizeDownSpeed;
        tf.localScale = new Vector3(_beamSize, _beamSize, tf.localScale.z);

        if (_beamSize <= 0) Destroy(_beam);
    }
}
