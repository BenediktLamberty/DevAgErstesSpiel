using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public void BecameBody(SpriteRenderer spriteRenderer, BoxCollider2D boxCollider2D)
    {
        spriteRenderer.enabled = false;
        boxCollider2D.enabled = false;
    }

    public void BecameSoul(SpriteRenderer spriteRenderer, BoxCollider2D boxCollider2D)
    {
        spriteRenderer.enabled = true;
        boxCollider2D.enabled = true;
    }
}
