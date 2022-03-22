using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponS1
{
    public string _wpName = "None";
    public int _wpNum = 0;
    public WeaponType _wpType = WeaponType.beam;
    public int _wpDamage = 0;
    public int _wpMagazine = 0;
    public float _wpRange = 0;
    public float _wpCooldown = -1;
    public float _wpStartup;
    public float _wpDelay;
    public Sprite _weaponImg;

    public WeaponS1(string wpName, int wpNum, WeaponType wpType , int wpDmg, int wpMagazine, float wpRan, float wpCool, float wpStartup, float wpDelay)
    {
        this._wpName = wpName;
        this._wpNum = wpNum;
        this._wpType = wpType;
        this._wpDamage = wpDmg;
        this._wpMagazine = wpMagazine;
        this._wpRange = wpRan;
        this._wpCooldown = wpCool;
        this._wpStartup = wpStartup;
        this._wpDelay = wpDelay;
        //this._weaponImg = _weaponImg;
    }

    public WeaponS1()
    {

    }
}
