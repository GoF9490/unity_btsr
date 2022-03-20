using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUIMnanger : MonoBehaviour
{
    public static HPUIMnanger Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<HPUIMnanger>();

            return instance;
        }
    }

    private static HPUIMnanger instance;

    [SerializeField] Slider _enemyHP;
    [SerializeField] Slider _p1HP;
    [SerializeField] Slider _p2HP;
    [SerializeField] Slider _p3HP;
    [SerializeField] Slider _p4HP;

    private void Start()
    {
        //_enemyHP.gameObject.SetActive(false);
        _p1HP.gameObject.SetActive(false);
        _p2HP.gameObject.SetActive(false);
        _p3HP.gameObject.SetActive(false);
        _p4HP.gameObject.SetActive(false);
    }

    public void HPUI_Enemy(int hpMax, int hp)
    {
        _enemyHP.maxValue = hpMax;
        _enemyHP.value = hp;
    }

    public void HPUI_Player(int num, int hpMax, int hp)
    {
        switch (num)
        {
            case 1:
                {
                    _p1HP.maxValue = hpMax;
                    _p1HP.value = hp;
                    return;
                }
            case 2:
                {
                    _p2HP.maxValue = hpMax;
                    _p2HP.value = hp;
                    return;
                }
            case 3:
                {
                    _p3HP.maxValue = hpMax;
                    _p3HP.value = hp;
                    return;
                }
            case 4:
                {
                    _p4HP.maxValue = hpMax;
                    _p4HP.value = hp;
                    return;
                }
        }
    }
}
