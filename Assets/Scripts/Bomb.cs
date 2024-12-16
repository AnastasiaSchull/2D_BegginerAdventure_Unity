using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]private Rigidbody2D rb;
    
    public void LoadBomb(Vector2 force)
    {
        rb.AddForce(force);
    }
}
