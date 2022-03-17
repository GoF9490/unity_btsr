using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 기본적인 목표는 불릿 오브젝트 풀(각 무기에 맞는 총탄을 스택큐 방식으로 온오프) 관리 - 웨폰셋으로도 가능
 * 총탄에 데미지 변수값도 넣어서 상대방이 총탄에 맞았을시 변수를 넘겨주도록 설정 - 웨폰셋으로도 가능
 * 당장에 필요한 이유가?
 */

public class BeamRifle : MonoBehaviour
{
    WeaponSet _wpSet;

    private void Start()
    {
        _wpSet = this.gameObject.GetComponent<WeaponSet>();
    } 
}
