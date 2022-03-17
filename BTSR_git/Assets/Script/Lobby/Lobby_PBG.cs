using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Lobby_PBG : MonoBehaviourPun
{
    GameObject _readyEff;
    [SerializeField] bool _ready = false;


    private void Start()
    {
        _readyEff = this.transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        CheckReady();
    }

    void CheckReady()
    {
        if (_ready) _readyEff.SetActive(true);
        else _readyEff.SetActive(false);
    }
}
