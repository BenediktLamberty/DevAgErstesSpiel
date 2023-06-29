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

    private bool _canMoveBox;
    public bool CanMoveBox
    {
        get { return _canMoveBox; }
        set { _canMoveBox = value; }
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
}
