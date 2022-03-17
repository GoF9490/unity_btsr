using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_WeaponS1 : MonoBehaviour
{
    PlayerStatus _ps;
    //일단 빔라이플 용으로
    WeaponType _weaponType = WeaponType.beam;
    int _wpDmg = 0;
    float _wpRan = 0;
    float _wpCool = 1;
    float _wpDelay = 0.3f;

    [SerializeField]
    float _attCool = 0;

    public GameObject _weapon;

    private void Start()
    {
        _ps = this.gameObject.GetComponent<PlayerStatus>();

        GetWeaponStat();

    }

    private void FixedUpdate()
    {
        Attack();
    }

    private void LateUpdate()
    {
        Cooling();
    }

    void GetWeaponStat()
    {
        int wps1 = PlayerDataCon.Instance.GetWeaponS1Num();
        _weaponType = WeaponDB.Instance._wpMapS1[wps1]._weaponType;
        _wpDmg = WeaponDB.Instance._wpMapS1[wps1]._weaponDamage;
        _wpRan = WeaponDB.Instance._wpMapS1[wps1]._weaponRange;
        _wpCool = WeaponDB.Instance._wpMapS1[wps1]._weaponCooldown;
        //_wpDelay = WeaponDB.Instance._wpMapS1[wps1]._weapon; 딜레이 변수 만들것

        _weapon = _ps._weaponS1;
        _weapon.GetComponent<WeaponSet>()._ps = _ps;
        _weapon.GetComponent<WeaponSet>().SetWeaponStat(_wpDmg, _wpRan);
    }

    void Attack()
    {     
        if (!_ps._lockon || _ps.GetDelay() == true) // 형식상
        {
            _ps.SetAttack(false);
            return;
        }
        

        InrangeCheck();

        if (_ps.GetAttack() && _attCool <= 0)
        {
            _attCool = _wpCool;
            //GameObject shot = Instantiate(_shot, _muzzle.position, Quaternion.identity);
            _weapon.GetComponent<WeaponSet>().SendMessage("Attack");
        }
    }

    void InrangeCheck()
    {
        if (_ps._target != _ps._mousePosition)
        {
            if (_ps._targetDistance <= _wpRan) _ps.SetAttack(true);
            else _ps.SetAttack(false);
        }
    }

    void Cooling()
    {
        if (_ps.GetAttack())
        {
            if (_attCool > 0) _attCool -= Time.deltaTime;
        }
        else _attCool = _wpDelay;
    }
}
