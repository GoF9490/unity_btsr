using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Lookat : MonoBehaviour
{
    [SerializeField] PlayerStatus ps;
    public Transform _tf;
    [SerializeField] Transform _dircon;
    [SerializeField] List<GameObject> _enemy;

    [SerializeField] GameObject _mousePos;

    float _rotSpeed = 8;
    float _targetDes = 0;

    private void Start()
    {
        ps = gameObject.GetComponent<PlayerStatus>();
        _tf = this.gameObject.transform;
        _dircon = ps.GetDircon();
        _enemy = GameObject.Find("TeamSplit").GetComponent<TeamList>()._enemy;
        //ps._mousePosition = GameObject.Find("MousePosition");
        _mousePos = ps._mousePosition;
    }

    private void FixedUpdate()
    {
        if (ps.GetDelay() == false)
        {
            TargetLockon();
            TargetDistance();
        }
    }

    private void LateUpdate() //나중에 딴곳으로 빼든가 어쩌든가
    {
        if (ps.GetDelay() == false)
        {
            Lookat_Keybord();
            Lookat_Mouse();
        }
    }

    void Lookat_Keybord()
    {
        //키보드(타겟온 형식)
        if (ps._target != _mousePos)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                AutoTarget();
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                ps._target = null;
            }
        }
    }

    void Lookat_Mouse()
    {
        //마우스 사용
        if (Input.GetMouseButton(0))
        {
            ps._target = _mousePos;
            ps.SetAttack(true);
        }
        else

        if (ps._target == _mousePos)
        {
            ps._target = null;
            ps.SetAttack(false);
        }
    }

    void TargetLockon()
    {
        if (ps._target != null)
        {
            ps._lockon = true;
        }
        else
        {
            ps._lockon = false;
        }

        if (!ps._lockon)
        {
            Moving();
        }

        if (ps._lockon)
        {
            Targeting();
        }
    }

    void Moving()
    {
        //tf의 로테이션값을 _DirCon의 로테이션 값까지 _rotSpeed * time 속도로 회전 / 보간 
        _tf.rotation = Quaternion.Slerp(_tf.rotation, _dircon.rotation, _rotSpeed * Time.fixedDeltaTime);
    }

    void Targeting()
    {
        //타겟 주시
        if (ps.Target() != null)
        {
            Vector3 vec = ps.Target().transform.position - transform.position;
            //vec.Normalize();
            //Quaternion q = Quaternion.LookRotation(vec);
            //transform.rotation = q;
            float angle = Mathf.Atan2(vec.x, vec.z) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);

            /*
            //발사
            if (targetDes <= wp1range)
            {
                transform.GetChild(1).GetComponent<weaponTrigger>()._fire = true;
            }
            else

            {
                transform.GetChild(1).GetComponent<weaponTrigger>()._fire = false;
            }
            */
        }
    }

    void AutoTarget()
    {
        _targetDes = Vector2.Distance(gameObject.transform.position, _enemy[0].transform.position);

        ps.Target(_enemy[0]);
        foreach (GameObject found in _enemy)
        {
            float distance = Vector2.Distance(gameObject.transform.position, found.transform.position);

            if (distance < _targetDes)
            {
                ps.Target(found);
                _targetDes = distance;
            }
        }
    }

    void TargetDistance()
    {
        if (ps._target != null)
        {
            Vector3 vec = new Vector3(_tf.position.x - ps._target.transform.position.x,
            0, _tf.position.z - ps._target.transform.position.z);

            ps._targetDistance = Vector3.Magnitude(vec);
        }
    }
}
