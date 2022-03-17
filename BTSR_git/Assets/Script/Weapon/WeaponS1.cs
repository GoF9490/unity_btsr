using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponS1
{
    public string _weaponName = "None";
    public int _weaponNum = 0;
    public WeaponType _weaponType = WeaponType.beam;
    public int _weaponDamage = 0;
    public float _weaponRange = 0;
    public float _weaponCooldown = -1;
    public Sprite _weaponImg;

    public WeaponS1(string _wpName, int _wpNum, WeaponType _wpType , int _wpDmg, float _wpRan, float _wpCool)
    {
        this._weaponName = _wpName;
        this._weaponNum = _wpNum;
        this._weaponType = _wpType;
        this._weaponDamage = _wpDmg;
        this._weaponRange = _wpRan;
        this._weaponCooldown = _wpCool;
        //this._weaponImg = _weaponImg;
    }

    public WeaponS1()
    {

    }
}
