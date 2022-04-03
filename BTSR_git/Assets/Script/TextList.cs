using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextList : MonoBehaviour
{
    public List<string> _list;

    protected void AddText(string str)
    {
        _list.Add(str);
    }
}
