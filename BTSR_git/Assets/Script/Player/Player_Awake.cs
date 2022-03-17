using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player_Awake : MonoBehaviour
{
    [SerializeField] PhotonView _pv;
    [SerializeField] PlayerStatus _ps;
    [SerializeField] Player_Move _pm;
    [SerializeField] Player_Lookat _pl;
    [SerializeField] Player_WeaponS1 _pw;
    [SerializeField] Player_Dodge _pd;

    void Start()
    {
        PlayerCharaSet();
        PlayerWpS1Set();
        _ps.enabled = true;
        if (_pv.IsMine)
        {
            _pm.enabled = true;
            _pl.enabled = true;
            _pw.enabled = true;
            _pd.enabled = true;
        }
    }

    void PlayerCharaSet()
    {
        int charaNum = PlayerDataCon.Instance.GetCharaNum();
        GameObject charaObj0 = CharaDB.Instance.gameObject.transform.GetChild(charaNum - 1).gameObject;
        GameObject charaObj = Instantiate(charaObj0, transform.position, Quaternion.identity);
        charaObj.transform.parent = this.transform;
        charaObj.transform.localPosition = new Vector3(0, 0, 0);
        charaObj.transform.localEulerAngles = new Vector3(0, 0, 0);
        charaObj.SetActive(true);
        Debug.Log("캐릭터 모델링 세팅");
    }

    void PlayerWpS1Set()
    {
        int wps1Num = PlayerDataCon.Instance.GetCharaNum();
        GameObject wps1Obj0 = WeaponDB.Instance.gameObject.transform.GetChild(wps1Num - 1).gameObject;
        GameObject wps1Obj = Instantiate(wps1Obj0, transform.position, Quaternion.identity);
        wps1Obj.transform.parent = this.gameObject.GetComponentInChildren<EquipPoint>()._handR.transform;
        wps1Obj.transform.localPosition = new Vector3(0, 0, 0);
        wps1Obj.transform.localEulerAngles = new Vector3(0, 0, 0);
        this.gameObject.GetComponent<PlayerStatus>()._weaponS1 = wps1Obj;
        wps1Obj.SetActive(true);
        Debug.Log("무기 모델링 세팅");
    }

    public void SetMouseDircon(GameObject mouse, GameObject dircon)
    {
        this.gameObject.GetComponent<PlayerStatus>().SetMouseDircon(mouse, dircon);
    }

}
