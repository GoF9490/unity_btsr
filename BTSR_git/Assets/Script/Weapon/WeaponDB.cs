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
        // 이름, 넘버, 타입, 데미지, 장탄수(0이면 탄창없음), 사거리, 쿨타임(장전시간), 선딜레이(무기를 드는 순간), 발사간격
        AddWp("None", 0, WeaponType.beam, 0, 0, 0, 0, 0, 0);
        AddWp("BeamRifle", 1, WeaponType.beam, 100, 0, 100, 2, 0.3f, 2);
        AddWp("BeamRifle2", 2, WeaponType.beam, 100, 0, 100, 2, 0.3f, 2);
    }

    void AddWp(string wpName, int wpNum, WeaponType wpType, int wpDmg, int wpMagazine, float wpRan, float wpCool, float wpStartup, float wpDelay)
    {
        _wpMapS1.Add(wpNum, new WeaponS1(wpName, wpNum, wpType, wpDmg, wpMagazine, wpRan, wpCool, wpStartup, wpDelay)); ;
    }
}
