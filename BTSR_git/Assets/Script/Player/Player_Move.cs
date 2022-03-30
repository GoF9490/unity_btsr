using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    protected Transform _tf;
    protected Transform _dirCon;
    protected Rigidbody _rb;

    [SerializeField] protected float _speed = 35;
    protected bool _moving = false;

    protected Vector3 _targetDir;
    protected Vector3 _conDir;
    float _vecZ = 0;
    public bool _forward = true;

    [Header("Dash")]
    bool _dash;
    Vector3 _dashPoint;
    float _dashSpeed = 0;
    float _dashTime = 0;

    //Player_Anim _pa;
    PlayerStatus _ps;

    void Start()
    {
        _tf = this.gameObject.transform;
        //_pa = this.gameObject.GetComponentInChildren<Player_Anim>();
        _ps = this.gameObject.GetComponent<PlayerStatus>();
        _rb = this.gameObject.GetComponent<Rigidbody>();
        _dirCon = _ps.GetDircon();
    }


    private void FixedUpdate()
    {
        if (_moving) Moving();
        MoveDir();
        Dash();
    }

    void Moving()
    {
        if (_dash == false)
        {
            _tf.position += _dirCon.forward * _speed * Time.deltaTime; // tf.position
            //_rb.MovePosition(_tf.position + _dirCon.forward * _speed * Time.deltaTime); // rb.movePosition
        }

    }

    public void StartDash(float distance, float dashSpeed)
    {
        _dashPoint = _tf.position + _dirCon.forward * distance;
        _dashSpeed = dashSpeed;
        _dash = true;
    }

    public void FMovement(Vector3 vec, float speed)
    {
        _ps.SetDelay(true); // 나중에 if문으로 예외처리 넣을지도
        _dashPoint = vec;
        _dashSpeed = speed;
        _dash = true;
    }

    void Dash()
    {
        if (_dash)
        {
            _dashTime += Time.deltaTime * _dashSpeed;
            _tf.position = Vector3.Lerp(_tf.position, _dashPoint, _dashTime);

            if (_dashTime >= 1)
            {
                _dash = false;
                _dashTime = 0;
                _tf.position = _dashPoint;

                if (_ps.GetDelay()) _ps.SetDelay(false);
                if (_ps.GetDodge()) _ps.SetDodge(false);
            }
        }
    }

    void MoveDir()
    {
        if (_ps._target != null)
        {
            _targetDir = _tf.position - _ps._target.transform.position;
            _conDir = _dirCon.forward;

            //_vecZ = Mathf.Abs(_conDir.normalized.z - _targetDir.normalized.z);
            _vecZ = Quaternion.FromToRotation(_conDir, _targetDir).eulerAngles.y;

            //Debug.Log(_vecZ);

            if (270 >= _vecZ && _vecZ >= 90)
            {
                _forward = true;
            }

            else
            {
                _forward = false;
            }
        }
        else _forward = true;
    }

    public bool CheckMove()
    {
        return _moving;
    }
}
