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
    private SpriteRenderer _playerSpriteRender;
    private BoxCollider2D _playerBoxCollider;
    private PlayerBodyController _playerBodyController;
    private Vector3 _mousePosition;

    private void Awake()
    {
        _playerModel = new PlayerModel();
        _playerView = GetComponent<PlayerView>();
        _playerSpriteRender = GetComponent<SpriteRenderer>();
        _playerBoxCollider = GetComponent<BoxCollider2D>();
        _playerModel.HasBody = false;
        _playerModel.Speed = 10f;
        _mousePosition = new Vector3(transform.position.x, transform.position.y, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Body"))
        {
            _playerModel.HasBody = true;
            _playerBodyController = collision.gameObject.GetComponent<PlayerBodyController>();
            _playerBodyController.BecamePlayer(this);
            _playerView.BecameBody(_playerSpriteRender, _playerBoxCollider);
        }
    }

    public void BecameSoul(Transform transform)
    {
        _playerView.BecameSoul(_playerSpriteRender, _playerBoxCollider);
        _playerModel.HasBody = false;
        this.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f , 0f);
        _mousePosition = new Vector3(transform.position.x, transform.position.y + 1.5f, 0f);

    }

    private void Update()
    {
        if (!_playerModel.HasBody)
            FlyToMousePosition(_playerModel.Speed);
    }

    private void FlyToMousePosition(float speed)  
    {
        if(Input.GetMouseButton(0))
        {
            _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _mousePosition.z = 0;
        }
        transform.position = Vector3.MoveTowards(transform.position, _mousePosition, Time.deltaTime * speed);
    }
}