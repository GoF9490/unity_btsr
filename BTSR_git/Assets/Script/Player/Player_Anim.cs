using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public enum playerAction
{
    stay,
    move,
    attack,
    dodge,
    special
}

public class Player_Anim : MonoBehaviourPun
{
    Animator _anim;
    PlayerStatus _ps;
    Player_Move _pm;
    PhotonView _pv;

    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _ps = GetComponentInParent<PlayerStatus>();
        //사용 기기에따라 처리해줘야 할듯. 일단 키보드
        _pm = GetComponentInParent<useKeybord>();
        _pv = GetComponentInParent<PhotonView>();
    }

    private void LateUpdate()
    {
        CheckAction();
        PlayAction();
    }

    void CheckAction()
    {
        if (_pv.IsMine)
        {
            if (_ps.GetDodge()) _ps._action = playerAction.dodge;
            else if (_ps.GetAttack()) _ps._action = playerAction.attack;
            else if (_pm.CheckMove()) _ps._action = playerAction.move;
            else _ps._action = playerAction.stay;
        }
    }

    void PlayAction()
    {
        AllOff();
        _anim.SetTrigger("action");
        BoolOn();
    }

    void AllOff()
    {
        _anim.SetBool("stay",false);
        _anim.SetBool("moveF", false);
        _anim.SetBool("moveB", false);
        _anim.SetBool("attack", false);
        _anim.SetBool("attackF", false);
        _anim.SetBool("attackB", false);
        _anim.SetBool("dodge", false);
        _anim.SetBool("special", false);
    }

    void BoolOn()
    {
        switch (_ps._action)
        {
            case playerAction.stay: _anim.SetBool("stay", true); break; // 정지

            case playerAction.move: // 이동
                if (_pm._forward) _anim.SetBool("moveF", true); // 앞이동
                else _anim.SetBool("moveB", true); break; // 뒷이동

            case playerAction.attack: // 공격
                if (!_pm.CheckMove()) _anim.SetBool("attack", true); // 정지
                else
                {
                    if (_pm._forward) _anim.SetBool("attackF", true); // 앞공격
                    else _anim.SetBool("attackB", true); // 뒷공격
                }
                break;

            case playerAction.dodge: _anim.SetBool("dodge", true); break; // 회피

            case playerAction.special: _anim.SetBool("special", true); break; // 스페셜
        }
    }
}
