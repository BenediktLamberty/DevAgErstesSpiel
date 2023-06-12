using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonModel
{
    private bool _isOn;
    public bool IsOn
    {
        get { return _isOn; }
        set { _isOn = value; }
    }

    public bool _isObjectOnTop;
    public bool IsObjectOnTop
    {
        get { return _isObjectOnTop; }
        set { _isObjectOnTop = value; }
    }

}
