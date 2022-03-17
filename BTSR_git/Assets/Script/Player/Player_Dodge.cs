using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Dodge : MonoBehaviour
{
    PlayerStatus _ps;
    Player_Move _pm;

    [SerializeField] float _dodgeCooltime = 3;
    float _dodgeCool = 0;

    private void Start()
    {
        _ps = this.gameObject.GetComponent<PlayerStatus>();
        _pm = this.gameObject.GetComponent<Player_Move>();
    }

    private void FixedUpdate()
    {
        Dodge();
        Cooldown();
    }

    void Dodge()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (_ps.GetDelay() == false && _dodgeCool <= 0)
            {
                Debug.Log("Dodge");
                _ps.SetDelay(true);
                _ps.SetDodge(true);
                _dodgeCool = _dodgeCooltime;
                _pm.StartDash(35, 2);
            }
        }
    }

    void Cooldown()
    {
        if (_dodgeCool >= 0)
        {
            _dodgeCool -= Time.deltaTime;
        }
    }
}
