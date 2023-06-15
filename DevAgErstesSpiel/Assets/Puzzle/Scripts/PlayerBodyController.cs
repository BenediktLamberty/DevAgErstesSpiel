using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyController : MonoBehaviour
{
    private PlayerBodyModel _playerBodyModel;
    private PlayerBodyView _playerBodyView;
    private Rigidbody2D _playerBodyRigidbody;
    private PlayerController _playerController;
    private GameObject _boxGameObject;
    private Rigidbody2D _boxRigidbody;

    public float BodySpeed;
    public float BodyJumpForce;
    public bool BodyIsBig;


    private void Awake()
    {
        _playerBodyModel = new PlayerBodyModel();
        _playerBodyView = GetComponent<PlayerBodyView>();
        _playerBodyRigidbody = GetComponent<Rigidbody2D>();
        _boxGameObject = GameObject.FindWithTag("Object");
        _boxRigidbody = _boxGameObject.GetComponent<Rigidbody2D>();
        _playerBodyModel.Speed = BodySpeed;
        _playerBodyModel.JumpForce = BodyJumpForce;
        _playerBodyModel.IsPlayer = false;
        _playerBodyModel.IsBig = BodyIsBig;
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
        if(_playerBodyModel.IsBig) 
        {
            _boxRigidbody.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnMouseUp()
    {
        if (_playerBodyModel.IsPlayer)
        {
            _playerBodyModel.IsPlayer = false;
            _playerController.BecameSoul(transform);
            if (_playerBodyModel.IsBig)
            {
                _boxRigidbody.bodyType = RigidbodyType2D.Kinematic;
            }
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
