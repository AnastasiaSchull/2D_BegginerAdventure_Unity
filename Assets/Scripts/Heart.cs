using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour, ICollideble
{
    private new SpriteRenderer renderer;

    [SerializeField] private EnemyMover enemyMover; 
    [SerializeField] private float speedIncrease = 4.0f; // на столько будет > скорость

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }
    public void Collide(Player player)
    {
       // Destroy(gameObject); //так мы удалтм сердце при взаимодействии с героем
       renderer.color = Color.cyan;//меняется цвет при взаимодействии с героем
        player.AddHearts(1); // ++1 жизнь 
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Player player))
        {
            enemyMover.speed += speedIncrease; // ++ скорость врага
            Debug.Log($"speed increased : {enemyMover.speed}");         
        }
    }
}

