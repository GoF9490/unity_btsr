using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoint : MonoBehaviour
{
    //public GameObject _hitEff;
    HealthStatus _hs;

    private void Start()
    {
        _hs = this.gameObject.GetComponent<HealthStatus>();
    }

    public void HitCheck(int dmg)
    {
        //Debug.Log(dmg);
        _hs.ReduceHP(dmg);
    }
}
