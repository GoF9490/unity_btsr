using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    Transform _transform;

    public GameObject _weaponS1;
    public GameObject _target;
    public GameObject _mousePosition;
    public Transform _dirCon;

    public playerAction _action = playerAction.stay;

    [SerializeField] bool _delay = false;
    [SerializeField] bool _dead = false;
    [SerializeField] bool _attack = false;
    [SerializeField] bool _dodge = false;

    public bool _lockon = false;

    public float _targetDistance = 0;

    private void OnEnable()
    {
        _transform = this.gameObject.transform;
    }

    private void Start()
    {
        //_muzzle = transform.Find("muzzle").gameObject; 다른 방법이 좋을듯 (모델링에서 무기 분리후 생각해보자)
    }

    public GameObject Target()
    {
        return _target;
    }

    public void Target(GameObject target)
    {
        _target = target;
    }

    public bool GetDelay()
    {
        return _delay;
    }

    public bool GetDead()
    {
        return _dead;
    }

    public bool GetAttack()
    {
        return _attack;
    }

    public bool GetDodge()
    {
        return _dodge;
    }

    public void SetDelay(bool delay)
    {
        this._delay = delay;
    }

    public void SetAttack(bool attack)
    {
        this._attack = attack;
    }

    public void SetDodge(bool dodge)
    {
        this._dodge = dodge;
    }

    public void SetMouseDircon(GameObject mouse, GameObject dir)
    {
        _mousePosition = mouse;
        _dirCon = dir.transform;
    }

    public Transform GetDircon()
    {
        return _dirCon;
    }

    //      캐릭터 / 무기 변수를 플레이어 스테이터스에서 쓸 일이 잇을까
    //      어짜피 게임시작시에 캐릭터 무기 다 알맞게 불러오고 데이터 가져올일이 없을것같은데, 있어도 playerDataCon 인스터스에서 가져오면 되고
    //[SerializeField] private Chara _character = new Chara();
    //[SerializeField] private WeaponS1 _wps1 = new WeaponS1();
    /* 
        public Chara GetChara()
        {
            return _character;
        }

        public void SetChara(Chara character)
        {
            _character = character;
        }

        public WeaponS1 GetWeaponS1()
        {
            return _wps1;
        }

        public void SetWeaponS1(WeaponS1 wps1)
        {
            _wps1 = wps1;
        }
    */
}
