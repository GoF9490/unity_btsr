using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour
{
    PlayerStatus ps;
    Transform _playerTf;
    Transform tf;
    Transform _targetTf;
    Camera cam;

    Vector3 vec;

    public bool _follow = false;

    float _cameraY = 0;
    float _cameraY2 = 0;
    const float _minY = 50;

    private void Start()
    {
        tf = this.transform;
        cam = this.GetComponent<Camera>();
    }

    private void Update()
    {
        Follow();
    }

    void Follow()
    {
        if (!_follow || _playerTf == null) return;

        if (ps._lockon)
        {
            TargetOn();
        }
        else
        
        if (!ps._lockon)
        {
            TargetOff();
        }
    }

    void TargetOn()
    {
        if (ps._target != null)
        {
            _targetTf = ps._target.transform;

            vec = new Vector3((_playerTf.position.x + _targetTf.position.x)/2,
                tf.position.y, (_playerTf.position.z + _targetTf.position.z)/2);

            //tf.position = vec;
            tf.position = Vector3.Lerp(tf.position, vec, 5 * Time.deltaTime);

            SetCameraY();
            cam.orthographicSize = _cameraY;
        }
    }

    void TargetOff()
    {
        vec = new Vector3(_playerTf.position.x, tf.position.y, _playerTf.position.z);
        tf.position = vec;

        cam.orthographicSize = _minY;
    }

    void SetCameraY()
    {
        _cameraY = Mathf.Abs(ps.transform.position.z - tf.position.z) + 20;
        _cameraY2 = Mathf.Abs(ps.transform.position.x - tf.position.x) / 5 * 3 + 10;

        if (_cameraY <= _cameraY2) _cameraY = _cameraY2;

        if (_cameraY <= _minY) _cameraY = _minY;
    }

    public void SetPlayer(GameObject player)
    {
        ps = player.GetComponent<PlayerStatus>();
        _playerTf = player.transform;
    }
}
