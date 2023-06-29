using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private ButtonModel _buttonModel;
    private ButtonView _buttonView;
    private Animator _buttonAnimator;
    private GameObject _doorGameObject;

    private void Awake()
    {
        _buttonModel = new ButtonModel();
        _buttonView = GetComponent<ButtonView>();
        _doorGameObject = transform.GetChild(0).gameObject;
        _buttonAnimator = GetComponent<Animator>();
        _buttonModel.IsOn = false;
        _buttonModel.ObjectsOnTop = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Body") || collision.gameObject.CompareTag("Object"))
        {
            _buttonModel.ObjectsOnTop++;
            ActivateButton();
        }
        Debug.Log(_buttonModel.ObjectsOnTop);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Body") || collision.gameObject.CompareTag("Object"))
        {
            ActivateButton();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Body") || collision.gameObject.CompareTag("Object"))
        {
            _buttonModel.ObjectsOnTop --;
            ActivateButton();
        }
        Debug.Log(_buttonModel.ObjectsOnTop);
    }

    private void ActivateButton()
    {
        if (_buttonModel.ObjectsOnTop == 0 && _buttonModel.IsOn)
        {
            _buttonView.DoorClose(_doorGameObject);
            _buttonView.ButtonOff(_buttonAnimator);
            _buttonModel.IsOn = false;
        }
        else if (_buttonModel.ObjectsOnTop > 0 && !_buttonModel.IsOn)
        {
            _buttonView.DoorOpen(_doorGameObject);
            _buttonView.ButtonOn(_buttonAnimator);
            _buttonModel.IsOn = true;
        }
    }
}
