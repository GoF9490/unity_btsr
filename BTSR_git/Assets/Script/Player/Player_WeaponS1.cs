using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_WeaponS1 : MonoBehaviour
{
    PlayerStatus _ps;
    //일단 빔라이플 용으로
    WeaponType _wpType = WeaponType.beam;
    int _wpDmg = 0;
    int _wpMagazine = 0;
    float _wpRan = 0;
    float _wpCool = 1;
    float _wpStartup = 0;
    float _wpDelay = 0;

    [SerializeField] float _attCool = 0;
    [SerializeField] float _nonCombat = 0;
    [SerializeField] float _useMagazine = 0;
    [SerializeField] LayerMask _layer;

    public GameObject _weapon;

    private void Start()
    {
        _ps = this.gameObject.GetComponent<PlayerStatus>();

        //SetWeaponStat();
        _useMagazine = _wpMagazine;

        _weapon = _ps._weaponS1;
        //_weapon.GetComponent<WeaponSet>()._ps = _ps;
        _weapon.GetComponent<WeaponSet>().SetWeaponStat(_wpDmg, _wpRan);

    }

    private void FixedUpdate()
    {
        AttackCheck();
    }

    private void LateUpdate()
    {
        Cooling();
    }

    public void SetWeaponStat(int wps1)
    {
        //int wps1 = PlayerDataCon.Instance.GetWeaponS1Num();
        _wpType = WeaponDB.Instance._wpMapS1[wps1]._wpType;
        _wpDmg = WeaponDB.Instance._wpMapS1[wps1]._wpDamage;
        _wpMagazine = WeaponDB.Instance._wpMapS1[wps1]._wpMagazine;
        _wpRan = WeaponDB.Instance._wpMapS1[wps1]._wpRange;
        _wpCool = WeaponDB.Instance._wpMapS1[wps1]._wpCooldown;
        _wpStartup = WeaponDB.Instance._wpMapS1[wps1]._wpStartup;
        _wpDelay = WeaponDB.Instance._wpMapS1[wps1]._wpDelay;
    }

    void AttackCheck()
    {     
        if (!_ps._lockon || _ps.GetDelay() == true) // 형식상
        {
            _ps.SetAttack(false);
            return;
        }

        if (_ps._target != _ps._mousePosition && _ps._targetDistance > _wpRan) // Inrange check
        {
            _ps.SetAttack(false);
            return;
        }

        if (_wpMagazine > 0) // magazine check
        {
            if (_useMagazine <= 0)
            {
                _ps.SetAttack(false);
                return;
            }
        }

        _ps.SetAttack(true);

        if (_ps.GetAttack() && _attCool <= 0)
        {
            Attack();
        }
    }

    void Attack()
    {
        _attCool = _wpDelay;
        if (_wpMagazine > 0) _useMagazine -= 1;
        //_weapon.GetComponent<WeaponSet>().SendMessage("Attack");

        if (_wpType == WeaponType.beam)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, _wpRan, _layer, QueryTriggerInteraction.Ignore))
            {
                Debug.Log("attack1");
                CheckHit(hit.collider.gameObject);
                Vector3 vec = hit.point;
                _weapon.GetComponent<WeaponSet>().Attack(vec, true);
            }
            else
            {
                Vector3 vec = transform.position + transform.forward * _wpRan;
                Debug.Log("attack2");
                _weapon.GetComponent<WeaponSet>().Attack(vec, false);
            }
        }
        else if (_wpType == WeaponType.bullet)
        {

        }
    }

    void Cooling()
    {
        if (_ps.GetAttack())
        {
            if (_wpMagazine > 0) _nonCombat = _wpCool;
            if (_attCool > 0) _attCool -= Time.deltaTime;
        }
        else
        {
            if (_attCool > _wpStartup) _attCool -= Time.deltaTime;
            else _attCool = _wpStartup;

            if (_nonCombat > 0) _nonCombat -= Time.deltaTime;
            else if (_useMagazine < _wpMagazine) _useMagazine = _wpMagazine;
        }
    }

    public void CheckHit(GameObject hit)
    {
        if (hit.tag.Equals("Enemy"))
        {
            if (hit.GetComponent<HitPoint>())
            {
                hit.GetComponent<HitPoint>().HitCheck(_wpDmg);
            }
        }
    }
}
