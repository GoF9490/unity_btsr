using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaDB : MonoBehaviour
{
    public static CharaDB Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<CharaDB>();

            return instance;
        }
    }

    private static CharaDB instance;

    public Dictionary<int, Chara> _charaMap = new Dictionary<int, Chara>();

    private void Start()
    {
        AddChara("None", 0, 0);
        AddChara("Guardner", 1, 1000);
    }

    void AddChara(string charaName, int charaNum, int charaHP)
    {
        _charaMap.Add(charaNum, new Chara(charaName, charaNum, charaHP));
    }
}
