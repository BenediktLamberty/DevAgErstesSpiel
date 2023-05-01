using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerModel _playerModel;
    private PlayerView _playerView;
    private Rigidbody2D _playerRigidbody;

    private void Start()
    {
        _playerModel = new PlayerModel();
        _playerView = GetComponent<PlayerView>();
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _playerModel.CanFly = false;
        _playerModel.Speed = 5f;
        _playerModel.JumpForce = 10f;
        _playerModel.MoveSpeed = 5f;
        _playerModel.IsGrounded = false;
    }

    private void Update()
    {
        if (_playerModel.CanFly)
            FlyToMousePosition(this.transform, _playerModel.Speed);
        else
            Movement();

    }
    private void FixedUpdate()
    {
        if (!_playerModel.CanFly)
            Fall();
    }


    private void Movement()
    {
        if (Input.GetMouseButtonDown(0) && _playerModel.IsGrounded)
        {
            _playerRigidbody.AddForce(Vector2.up * _playerModel.JumpForce, ForceMode2D.Impulse);   
            _playerModel.IsGrounded = false;
        }
        if (Input.GetMouseButtonDown(1))
        {
            _playerRigidbody.velocity = new Vector2(_playerModel.MoveSpeed, _playerRigidbody.velocity.y);
        }
    }

    private void Fall()
    {
        if (!_playerModel.IsGrounded)
            _playerRigidbody.velocity += Physics2D.gravity * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        _playerModel.IsGrounded = true;
    }


    private Vector3 _targetPosition;
    private bool _isMoving;
    private void FlyToMousePosition(Transform transform, float speed)  
    {

        if (Input.GetMouseButtonDown(0))
            _isMoving = true;

        if (Input.GetMouseButtonUp(0))
            _isMoving = false;

        if (_isMoving)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            _targetPosition = mousePosition;
        }
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, Time.deltaTime * speed);
    }
}
