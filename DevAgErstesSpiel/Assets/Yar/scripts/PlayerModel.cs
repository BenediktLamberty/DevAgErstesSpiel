using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PlayerModel
{
    private bool _canFly;
    public bool CanFly
    {
        get { return _canFly; }
        set { _canFly = value; }
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
    
    private float _moveSpeed;
    public float MoveSpeed
    {
        get { return _moveSpeed; }
        set { _moveSpeed = value; }
    }

    private bool _isGrounded;
    public bool IsGrounded
    {
        get { return _isGrounded; }
        set { _isGrounded = value; }
    }
}
