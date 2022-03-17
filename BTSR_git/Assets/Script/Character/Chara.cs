using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara : MonoBehaviour
{
    public string _charaName = "None";
    public int _charaNum = 0;

    public Chara(string charaName, int charaNum)
    {
        this._charaName = charaName;
        this._charaNum = charaNum;
    }

    public Chara()
    {

    }
}
