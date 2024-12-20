using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    public float speed;
    public float damage;
    public float lifetime;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
  
        BanditMover bandit = collision.GetComponent<BanditMover>();
        if (bandit != null)
        {
            // наносим урон врагу пулей
            bandit.TakeDamage(damage);

            // уничтожаем пулю 
            Destroy(gameObject);
        }
        else
        {          
            Destroy(gameObject);
        }
    }
}
