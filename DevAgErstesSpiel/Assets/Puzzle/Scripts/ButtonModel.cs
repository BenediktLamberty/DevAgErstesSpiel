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

    public int _objectsOnTop;
    public int ObjectsOnTop
    {
        get { return _objectsOnTop; }
        set { _objectsOnTop = value; }
    }

}
