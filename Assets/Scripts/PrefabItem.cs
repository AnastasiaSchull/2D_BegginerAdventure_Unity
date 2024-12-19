using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabItem : MonoBehaviour, ICollideble
{
    [SerializeField] Item item;
    public void Collide(Player player)
    {
        player.inventory.AddItem(item, 1);
        Destroy(gameObject);
    }
}

