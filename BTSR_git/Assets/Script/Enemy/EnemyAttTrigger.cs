using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttTrigger : MonoBehaviour
{
    GameObject _obj;
    bool _start = false;
    float _timer = 0;
    string _pattern;

    private void FixedUpdate()
    {
        if (_start)
        {
            if (_timer >= 0) _timer -= Time.deltaTime;
            else if (_timer <= 0)
            {
                _obj.SendMessage(_pattern);
                Destroy(this.gameObject);
            }
        }
    }

    public void AttTrigger(GameObject obj, float timer, string pattern)
    {
        this._obj = obj;
        this._timer = timer;
        this._pattern = pattern;
        this._start = true;
    }
}
