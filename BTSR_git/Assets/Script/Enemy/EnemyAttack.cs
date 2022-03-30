using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] int _damage = 0;
    [SerializeField] bool _once = false;

    private void OnEnable()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;

        if (obj.tag.Equals("Player"))
        {
            Debug.Log("hit");
            if (obj.GetComponent<HealthStatus>()) obj.GetComponent<HealthStatus>().ReduceHP(_damage);
            if (obj.GetComponent<Player_Move>()) obj.GetComponent<Player_Move>().FMovement(obj.transform.position + transform.forward * 50, 3);

            if (_once) gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
