using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLineRenter : MonoBehaviour
{
    LineRenderer lr;
    Vector3 cube1Pos, cube2Pos;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.startWidth = 1f;
        lr.endWidth = 1f;

        cube1Pos = gameObject.GetComponent<Transform>().position;
    }

    void Update()
    {
        lr.SetPosition(0, GetComponent<Transform>().position);
        lr.SetPosition(1, GameObject.Find("Cube2").GetComponent<Transform>().position);
    }

}
