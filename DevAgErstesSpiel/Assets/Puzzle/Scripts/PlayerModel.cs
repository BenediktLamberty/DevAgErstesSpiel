using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PlayerModel
{
    private bool _hasBody;
    public bool HasBody 
    {
        get { return _hasBody; }
        set { _hasBody = value; }
    }

    private float _speed;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
}
