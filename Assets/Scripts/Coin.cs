using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollideble
{
    public void Collide(Player player)
    {
        player.AddCoins(5); // ++ 1 монетку или 5)
        Destroy(gameObject);//-- монетку
    }
}
