using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player_Awake : MonoBehaviourPun
{
    [SerializeField] PhotonView _pv;
    [SerializeField] PlayerStatus _ps;
    [SerializeField] Player_Move _pm;
    [SerializeField] Player_Lookat _pl;
    [SerializeField] Player_WeaponS1 _pw;
    [SerializeField] Player_Dodge _pd;
    [SerializeField] HealthStatus _hs;

    void Start()
    {
        _pv = this.gameObject.GetComponent<PhotonView>();
        _ps = this.gameObject.GetComponent<PlayerStatus>();
        _pm = this.gameObject.GetComponent<Player_Move>();
        _pl = this.gameObject.GetComponent<Player_Lookat>();
        _pw = this.gameObject.GetComponent<Player_WeaponS1>();
        _pd = this.gameObject.GetComponent<Player_Dodge>();
        _hs = this.gameObject.GetComponent<HealthStatus>();

        if (_pv.IsMine)
        {
            _pv.RPC("PlayerCharaSet", RpcTarget.AllBuffered, PlayerDataCon.Instance.GetCharaNum(), GameManager.Instance.GetLocalNum());
            _pv.RPC("PlayerWpS1Set", RpcTarget.AllBuffered, PlayerDataCon.Instance.GetWeaponS1Num());
        }
        _ps.enabled = true;
        _hs.enabled = true; // 지켜보자
        //TeamList.Instance.AddTeam("Player", this.gameObject);
        TeamList.Instance.SerchTeam();

        if (_pv.IsMine)
        {
            _pm.enabled = true;
            _pl.enabled = true;
            _pw.enabled = true;
            _pd.enabled = true;
        }
    }

    [PunRPC]
    void PlayerCharaSet(int charaNum, int localNum)
    {
        //int charaNum = PlayerDataCon.Instance.GetCharaNum();
        GameObject charaObj0 = CharaDB.Instance.gameObject.transform.GetChild(charaNum - 1).gameObject;
        GameObject charaObj = Instantiate(charaObj0, transform.position, Quaternion.identity);
        charaObj.transform.parent = this.transform;
        charaObj.transform.localPosition = new Vector3(0, 0, 0);
        charaObj.transform.localEulerAngles = new Vector3(0, 0, 0);
        charaObj.SetActive(true);
        HPUIMnanger.Instance.HPUI_On(localNum);
        _hs.SetMaxHP(charaNum);
        //Debug.Log("캐릭터 모델링 세팅");
    }

    [PunRPC]
    void PlayerWpS1Set(int wps1Num)
    {
        //int wps1Num = PlayerDataCon.Instance.GetWeaponS1Num();
        GameObject wps1Obj0 = WeaponDB.Instance.gameObject.transform.GetChild(wps1Num - 1).gameObject;
        GameObject wps1Obj = Instantiate(wps1Obj0, transform.position, Quaternion.identity);
        wps1Obj.transform.parent = this.gameObject.GetComponentInChildren<EquipPoint>()._handR.transform;
        wps1Obj.transform.localPosition = new Vector3(0, 0, 0);
        wps1Obj.transform.localEulerAngles = new Vector3(0, 0, 0);
        _ps._weaponS1 = wps1Obj;
        _pw.SetWeaponStat(wps1Num);
        wps1Obj.SetActive(true);
        //Debug.Log("무기 모델링 세팅");
    }

    public void SetMouseDircon(GameObject mouse, GameObject dircon)
    {
        this.gameObject.GetComponent<PlayerStatus>().SetMouseDircon(mouse, dircon);
    }

}
