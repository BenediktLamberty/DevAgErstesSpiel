using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public GameManagerScript gameManager;
    private Camera playerCamera;

    private float _moveSpeed;
    public float MoveSpeed
    {
        get { return _moveSpeed; }
        set { _moveSpeed = value; }
    }
    private float _jumpForce;
    public float JumpForce
    {
        get { return _jumpForce; }
        set { _jumpForce = value; }
    }

    private bool _isGrounded;
    public bool IsGrounded
    {
        get { return _isGrounded; }
        set { _isGrounded = value; }
    }

    private int _health;
    public int Health
    {
        get { return _health; }
        set { _health = value; }
    }

    private bool _isDead;
    public bool IsDead
    {
        get { return _isDead; }
        set { _isDead = value; }
    }

    private void Start()
    {
        MoveSpeed = 5f;
        JumpForce = 10f;
        IsGrounded = true;
        Health = 10;
        IsDead = false;
        playerCamera = Camera.main;
    }

    private void Update()
    {
        if (Health <= 0 && !IsDead)
        {
            gameManager.GameOver();
            IsDead = true;
            Debug.Log("Dead by Model");
        }
        CameraFollow(playerCamera);
    }

    private void CameraFollow(Camera camera)
    {
        Vector3 target = new Vector3(transform.position.x + 5f, camera.transform.position.y, camera.transform.position.z);
        Vector3 currentPosition = Vector3.Lerp(camera.transform.position, target, 1.5f * Time.deltaTime);
        currentPosition.y = transform.position.y;
        camera.transform.position = currentPosition;
    }

}
