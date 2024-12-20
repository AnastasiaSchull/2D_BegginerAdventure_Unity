using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour, ICollideble
{
    private new SpriteRenderer renderer;
  
    private Collider2D collider;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>(); 
    }
    public void Collide(Player player)
    {
        if (renderer.color == Color.cyan)
        {

        }
        else
        {
            // Destroy(gameObject); //так мы удалтм сердце при взаимодействии с героем
            renderer.color = Color.cyan;//меняется цвет при взаимодействии с героем
            player.AddHearts(1); // ++1 жизнь 
            collider.enabled = false;// откл коллайдер, чтоб не реагировать на столкновения
        }
    }

}

