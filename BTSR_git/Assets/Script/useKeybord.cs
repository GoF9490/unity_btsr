using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class useKeybord : Player_Move
{
    void Update()
    {
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            _dirCon.localEulerAngles = new Vector3(0, -135, 0);
            _moving = true;
        }
        else

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            _dirCon.localEulerAngles = new Vector3(0, 135, 0);
            _moving = true;
        }
        else

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            _dirCon.localEulerAngles = new Vector3(0, -45, 0);
            _moving = true;
        }
        else

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            _dirCon.localEulerAngles = new Vector3(0, 45, 0);
            _moving = true;
        }
        else

        if (Input.GetKey(KeyCode.W))
        {
            _dirCon.localEulerAngles = new Vector3(0, 0, 0);
            _moving = true;
        }
        else

        if (Input.GetKey(KeyCode.S))
        {
            _dirCon.localEulerAngles = new Vector3(0, 180, 0);
            _moving = true;
        }
        else

        if (Input.GetKey(KeyCode.A))
        {
            _dirCon.localEulerAngles = new Vector3(0, -90, 0);
            _moving = true;
        }
        else

        if (Input.GetKey(KeyCode.D))
        {
            _dirCon.localEulerAngles = new Vector3(0, 90, 0);
            _moving = true;
        }

        else _moving = false;
    }
}
