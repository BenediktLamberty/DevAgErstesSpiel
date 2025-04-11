using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private ButtonModel _buttonModel;
    private ButtonView _buttonView;
    private BoxCollider2D _boxCollider2D;
    private GameObject _buttonChild;
    private GameObject _doorGameObject;

    private void Awake()
    {
        _buttonModel = new ButtonModel();
        _buttonView = GetComponent<ButtonView>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _buttonChild = transform.GetChild(0).gameObject;
        _doorGameObject = GameObject.FindWithTag("Door");
        _buttonModel.IsOn = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Body") && !_buttonModel.IsOn)
        {
            _buttonView.ButtonOn(_buttonChild);
            _buttonView.DoorOpen(_doorGameObject);
            _buttonModel.IsOn = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Body") && _buttonModel.IsOn)
        {
            _buttonView.ButtonOff(_buttonChild);
            _buttonView.DoorClose(_doorGameObject);
            _buttonModel.IsOn = false;
        }
    }
}
