using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    Vector3 _pos = new Vector3(0, 0, 0);

    private void FixedUpdate()
    {
        this.transform.position = _pos;
    }
    private void LateUpdate()
    {
        _pos = Camera.main.ScreenToWorldPoint(new Vector3(
            Input.mousePosition.x, Input.mousePosition.y, 25)); 
        // 30이라는 값이 마우스포인트 오브젝트의 Y값을 보정해줌. 일단은 임시방편, 이유를 발견하면 알맞게 수정하는게 좋을듯.
        // 30이 메인 카메라의 높이같아보임. 당장에 문제될게 없으면 그대로 가도 될듯.
    }
}
