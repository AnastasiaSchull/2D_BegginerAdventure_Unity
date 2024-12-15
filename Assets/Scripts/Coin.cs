using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollideble
{
    public void Collide(Player player)
    {
        player.AddCoins(1); // ++ 1 монетку 
        Destroy(gameObject);//-- монетку
    }
}
