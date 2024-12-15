using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour, ICollideble
{
    [SerializeField] private EnemyMover enemyMover;
    [SerializeField] private float speedIncrease = 4.0f; // на столько будет < скорость
    [SerializeField] private Heart heart;

    public void Collide(Player player)
    {
        player.AddCrystals(1);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Player player))
        {
            enemyMover.speed -= speedIncrease; // ++ скорость врага
        }
        // отключим триггер Heart
        if (heart != null)
        {
           // heart.gameObject.SetActive(false); // убираем объект Heart
            heart.GetComponent<Collider2D>().enabled = false;
        }
    }
}

