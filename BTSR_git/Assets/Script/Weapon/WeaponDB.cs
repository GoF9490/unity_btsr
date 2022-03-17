using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    beam,
    bullet
}

public class WeaponDB : MonoBehaviour
{

    public static WeaponDB Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<WeaponDB>();

            return instance;
        }
    }

    private static WeaponDB instance;

    public Dictionary<int, WeaponS1> _wpMapS1 = new Dictionary<int, WeaponS1>();

    private void Start()
    {
        AddWp("None", 0, WeaponType.beam, 0, 0, 0);
        AddWp("BeamRifle", 1, WeaponType.beam, 100, 100, 2);
    }

    void AddWp(string _wpName, int _wpNum, WeaponType _wpType, int _wpDmg, float _wpRan, float _wpCool)
    {
        _wpMapS1.Add(_wpNum, new WeaponS1(_wpName, _wpNum, _wpType, _wpDmg, _wpRan, _wpCool)); ;
    }
}
