using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyModel
{
    private bool _isPlayer;
    public bool IsPlayer
    {
        get { return _isPlayer; }
        set { _isPlayer = value; }
    }

    private bool _isFrightened;
    public bool IsFrightened
    {
        get { return _isFrightened; }
        set { _isFrightened = value; }
    }

    private float _speed;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    private float _jumpForce;
    public float JumpForce
    {
        get { return _jumpForce; }
        set { _jumpForce = value; }
    }

    private Vector3 _avoid;
    public Vector3 Avoid
    {
        get { return _avoid; }
        set { _avoid = value; }
    }

    private int _freeze;
    public int Freeze
    {
        get { return _freeze; }
        set { _freeze = value; }
    }
}
