using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : PlayerMovement
{
    public Transform playerTransform;
    private float speed = 10f;

    private void Update()
    {
        MoveToMouse(playerTransform, speed);
        
    }
}
