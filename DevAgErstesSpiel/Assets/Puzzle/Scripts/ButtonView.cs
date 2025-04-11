using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonView : MonoBehaviour
{
    public void ButtonOn(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    public void ButtonOff(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    public void DoorOpen(GameObject gameObject)
    {
        gameObject.SetActive(false);    
    }

    public void DoorClose(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
}
