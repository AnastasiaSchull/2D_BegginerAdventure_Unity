using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollideble
{
    public void Collide(Player player)
    {
        Destroy(gameObject);
    }
}
