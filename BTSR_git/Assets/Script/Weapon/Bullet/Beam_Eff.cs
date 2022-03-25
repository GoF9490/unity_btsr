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

    void BeamEff()
    {
        _beamSize -= Time.deltaTime * _sizeDownSpeed;
        tf.localScale = new Vector3(_beamSize, _beamSize, tf.localScale.z);

        if (_beamSize <= 0) _beam.GetComponent<BulletStat>().CallEnqueue();
    }
}
