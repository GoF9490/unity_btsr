using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnemyAttTrigger : MonoBehaviourPun
{
    GameObject _obj;
    bool _start = false;
    float _timer = 0;
    string _pattern;

    private void FixedUpdate()
    {
        if (_start)
        {
            if (_timer >= 0) _timer -= Time.deltaTime;
            else if (_timer <= 0)
            {
                _obj.SendMessage(_pattern);
                this.gameObject.GetComponent<PhotonView>().RPC("DestroyObj", RpcTarget.AllBuffered);
            }
        }
    }

    public void AttTrigger(GameObject obj, float timer, string pattern)
    {
        this._obj = obj;
        this._timer = timer;
        this._pattern = pattern;
        this._start = true;
    }

    [PunRPC]
    void DestroyObj()
    {
        Destroy(this.gameObject);
    }

}
