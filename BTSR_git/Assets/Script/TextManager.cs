using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//스트링 리스트를 담고있는 스크립트 하나를 만들고, 그 스크립트를 상속받는 스크립트에 원하는 텍스트를 입력,
//이 스크립트에서 스트링 배열을 불러와서 해당 길이를 불러와 길이에 따른 스트링 리스트를 호출해 표현, 길이가 끝에 다다르면 종료하게끔.
public class TextManager : MonoBehaviour
{
    TextList _tl;
    public Text _txt;
    [SerializeField] int _num = 0;
    int _lastNum = 0;

    private void Start()
    {
        _tl = this.gameObject.GetComponent<TextList>();
        _lastNum = _tl._list.Count;
    }

    private void Update()
    {
        PrintText();
    }

    private void LateUpdate()
    {
        //NextText();
    }

    public void StartText()
    {
        Time.timeScale = 0;
        _num = 1;
    }

    public void PrintText()
    {
        if (_num > _lastNum)
        {
            _txt.text = "End";
            Time.timeScale = 1;
        }

        else if (_num > 0)
        {
            _txt.text = _tl._list[_num - 1];
        }
    }

    public void NextText()
    {
        if (_num <= _lastNum)
        {
            //Time.timeScale = 0;
            _num += 1;
        }
    }
}
