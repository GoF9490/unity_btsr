using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lobby_Equip : MonoBehaviour
{
    [SerializeField] Dropdown _charaDD;
    [SerializeField] Dropdown _weaponDD;
    [SerializeField] Button _readyBt;

    private void Update()
    {
        EquipLock();
        ReadyLock();
        EquipData();
    }

    void EquipLock()
    {
        if (LobbyManager.Instance.GetReady())
        {
            _charaDD.interactable = false;
            _weaponDD.interactable = false;
        }
        else
        {
            _charaDD.interactable = true;
            _weaponDD.interactable = true;
        }
    }

    void ReadyLock()
    {
        if (_charaDD.value == 0 || _weaponDD.value == 0) _readyBt.interactable = false;
        else
        {
            //if (LobbyManager.Instance.RoomMaster()) return; // 방장 기능이 필요하다면
            _readyBt.interactable = true;
        }
    }

    void EquipData()
    {
        PlayerDataCon.Instance.ChangeChara(_charaDD.value);
        PlayerDataCon.Instance.ChangeWeaponS1(_weaponDD.value);
    }
}
