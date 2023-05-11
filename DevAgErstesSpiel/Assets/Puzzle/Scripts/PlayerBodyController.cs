using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyController : MonoBehaviour
{
    private PlayerBodyModel _playerBodyModel;
    private PlayerBodyView _playerBodyView;
    private Rigidbody2D _playerBodyRigidbody;
    private PolygonCollider2D _playerBodyPolygonCollider;
    private PlayerController _playerController;

    private void Awake()
    {
        _playerBodyModel = new PlayerBodyModel();
        _playerBodyView = GetComponent<PlayerBodyView>();
        _playerBodyRigidbody = GetComponent<Rigidbody2D>();
        _playerBodyPolygonCollider = GetComponent<PolygonCollider2D>();
        _playerBodyModel.Speed = 10f;
        _playerBodyModel.JumpForce = 10f;
        _playerBodyModel.IsPlayer = false;
    }

    private void Update()
    {
        if(_playerBodyModel.IsPlayer)
        {
            Movement(_playerBodyModel.Speed, _playerBodyModel.JumpForce);
        }
    }

    public void BecamePlayer(PlayerController playerController)
    {
        _playerController = playerController;
        _playerBodyModel.IsPlayer = true;
    }

    private void OnMouseUp()
    {
        if (_playerBodyModel.IsPlayer)
        {
            _playerBodyModel.IsPlayer = false;
            _playerController.BecameSoul(transform);
        }

    }

    private void Movement(float speed, float jumpForce)
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, 0f);
            if (Input.GetKeyDown(KeyCode.A) && Mathf.Abs(_playerBodyRigidbody.velocity.y) < 0.001f)
                _playerBodyRigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, 0f);
            if (Input.GetKeyDown(KeyCode.D) && Mathf.Abs(_playerBodyRigidbody.velocity.y) < 0.001f)
                _playerBodyRigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    /*
    private void CameraFollow(Camera camera)
    {
        Vector3 target = new Vector3(transform.position.x + 0f, 5f, camera.transform.position.z);
        Vector3 currentPosition = Vector3.Lerp(camera.transform.position, target, 1.5f * Time.deltaTime);
        camera.transform.position = currentPosition;
    }
    */
}
