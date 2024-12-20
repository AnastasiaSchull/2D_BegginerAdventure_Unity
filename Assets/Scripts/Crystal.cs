using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour, ICollideble
{
    [SerializeField] private Heart heart;

    public void Collide(Player player)
    {
        player.AddCrystals(1);
        Destroy(gameObject);
    } 
}

