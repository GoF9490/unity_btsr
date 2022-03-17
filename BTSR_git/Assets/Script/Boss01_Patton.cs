using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01_Patton : MonoBehaviour
{
    [SerializeField] Transform _dashPoint;
    Transform _tf;

    [SerializeField] float _pattonCool = 0;

    private void Start()
    {
        _tf = gameObject.transform;
        _dashPoint = _tf.Find("DashPoint");
    }

    private void FixedUpdate()
    {
        Cooldown();
    }

    void Cooldown()
    {
        if (_pattonCool >= 0)
        {
            _pattonCool -= Time.deltaTime;
        }
    }
}
