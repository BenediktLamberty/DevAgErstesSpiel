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
        _playerBodyModel.IsFrightened = false;
        _playerBodyModel.Avoid = new Vector3(Random.Range(-25f, 25f), 0f, 0f);
        _playerBodyModel.Freeze = 0;
    }

    private void Update()
    {
        if(_playerBodyModel.IsPlayer)
        {
            Movement(_playerBodyModel.Speed, _playerBodyModel.JumpForce);
        }
        else
        {
            NPCMovement(_playerBodyModel.Speed);
        }
    }

    public void BecamePlayer(PlayerController playerController)
    {
        _playerController = playerController;
        _playerBodyModel.IsPlayer = true;
        _playerBodyModel.IsFrightened = true;
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
        Debug.Log("Player");
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

    private void NPCMovement(float speed)
    {
        if (_playerBodyModel.IsFrightened)
        {
            _playerBodyModel.Avoid = _playerController.transform.position;
            if (Mathf.Abs(Vector3.Distance(transform.position, _playerBodyModel.Avoid)) < 5f)
            {
                transform.position += new Vector3(Mathf.Sign((transform.position - _playerBodyModel.Avoid).x) * (5 - Mathf.Abs((transform.position - _playerBodyModel.Avoid).x)) * speed * Time.deltaTime / 5f, 0f, 0f);
            }

        }
        else if (_playerBodyModel.Freeze <= 0)
        {
            Debug.Log(Vector3.Distance(transform.position, _playerBodyModel.Avoid));
            if (Mathf.Abs(Vector3.Distance(transform.position, _playerBodyModel.Avoid)) < 3f)
            {
                transform.position += new Vector3(Mathf.Sign((transform.position - _playerBodyModel.Avoid).x) * (3 - Mathf.Abs((transform.position - _playerBodyModel.Avoid).x)) * speed * Time.deltaTime / 3f, 0f, 0f);
            }
            else
            {
                _playerBodyModel.Avoid = new Vector3(Random.Range(-10f, 10f), Random.Range(-5f, 5f), 0f);
                _playerBodyModel.Freeze = 100;
            }
        }
        _playerBodyModel.Freeze--;
    }



    /*
    private void CameraFollow(Camera camera)
    {
        Vector3 target = new Vector3(transform.position.x + 0f, 0f, camera.transform.position.z);
        Vector3 currentPosition = Vector3.Lerp(camera.transform.position, target, 1.5f * Time.deltaTime);
        camera.transform.position = currentPosition;
    }
    */
}
