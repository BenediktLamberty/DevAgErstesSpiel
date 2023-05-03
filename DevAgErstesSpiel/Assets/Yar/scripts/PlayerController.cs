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
    private Camera _playerCamera;

    private void Awake()
    {
        _playerModel = new PlayerModel();
        _playerView = GetComponent<PlayerView>();
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _playerModel.CanFly = true;
        _playerModel.Speed = 10f;
        _playerModel.JumpForce = 10f;
        _playerModel.IsGrounded = false;
        _playerCamera = Camera.main;
        _mousePosition = new Vector3(transform.position.x, transform.position.y, 0f);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            _playerModel.CanFly = true;
            _mousePosition = new Vector3(transform.position.x, transform.position.y, 0f);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            _playerModel.CanFly = false;
        }

        if (_playerModel.CanFly)
            FlyToMousePosition(this.transform, _playerModel.Speed);
        else
        {
            Movement(_playerModel.Speed, _playerModel.JumpForce);
            CameraFollow(_playerCamera);
        }
    }

    private void Movement(float speed, float jumpForce)
    {
        _playerRigidbody.bodyType = RigidbodyType2D.Dynamic;
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(_playerRigidbody.velocity.y) < 0.05f)
            _playerRigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }

    private void CameraFollow(Camera camera)
    {
        Vector3 target = new Vector3(transform.position.x + 8f, 4.5f, camera.transform.position.z);
        Vector3 currentPosition = Vector3.Lerp(camera.transform.position, target, 1.5f * Time.deltaTime);
        camera.transform.position = currentPosition;
    }

    private Vector3 _mousePosition;
    private bool _isMoving;
    private void FlyToMousePosition(Transform transform, float speed)  
    {
        _playerRigidbody.bodyType = RigidbodyType2D.Static;
        if (Input.GetMouseButtonDown(0))
            _isMoving = true;

        if (Input.GetMouseButtonUp(0))
            _isMoving = false;

        if (_isMoving)
        {
            _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _mousePosition.z = 0;
        }
        transform.position = Vector3.MoveTowards(transform.position, _mousePosition, Time.deltaTime * speed);
    }
}