using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Chara
{
    public string _charaName = "None";
    public int _charaNum = 0;
    public int _charaHP = 0;

    public Chara(string charaName, int charaNum, int charaHP)
    {
        this._charaName = charaName;
        this._charaNum = charaNum;
        this._charaHP = charaHP;
    }

    public Chara()
    {

    }
}
