using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonView : MonoBehaviour
{
    public void ButtonOn(Animator animator)
    {
        animator.SetBool("IsOn", true);
    }

    public void ButtonOff(Animator animator)
    {
        animator.SetBool("IsOn", false);
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
