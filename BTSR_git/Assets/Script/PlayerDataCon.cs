using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class PlayerDataCon : MonoBehaviour
{
    public static PlayerDataCon Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<PlayerDataCon>();

            return instance;
        }
    }

    private static PlayerDataCon instance;

    PlayerData _data;

    bool _change = false;

    private void Awake()
    {
        LoadData();
    }

    private void OnDestroy()
    {
        if (_change == true) SaveData();
    }

    void LoadData()
    {
        string path = Path.Combine(Application.dataPath, "PlayerData.json");
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            _data = JsonUtility.FromJson<PlayerData>(jsonData);
            Debug.Log("Load");
        }
        else

        {
            Debug.Log("NewData");
            _data = new PlayerData();
        }
    }

    void SaveData()
    {
        string jsonData = JsonUtility.ToJson(_data, true);
        string path = Path.Combine(Application.dataPath, "PlayerData.json");
        File.WriteAllText(path, jsonData);
        Debug.Log("Save");
    }

    public void ChangeChara(int num)
    {
        _change = true;
        _data.equip_chara = num;
    }

    public void ChangeWeaponS1(int num)
    {
        _change = true;
        _data.equip_wps1 = num;
    }

    public int GetCharaNum()
    {
        return _data.equip_chara;
    }

    public int GetWeaponS1Num()
    {
        return _data.equip_wps1;
    }
}
