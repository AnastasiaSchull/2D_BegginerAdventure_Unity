﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditMover : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    public float attackRange; // радиус атаки
    public float closeRange;  // радиус ближнейатаки
    public float health = 100f; // здоровье бандита

    private bool isAttacking = false;
    private bool isClose = false;
    private bool isDead = false;

    [SerializeField] private new Collider2D collider2D;
    [SerializeField] private int attackDamage = 1;

    [SerializeField] private AudioSource audioSource; // компонент, который проигрывает аудио файлы,  а AudioClip(в инспекторе) — это файл со звуком
    [SerializeField] private AudioClip swordAttackSound; // сам звук меча

    [SerializeField] private AudioClip bulletHitSound; 

    private void Start()
    {
        collider2D = GetComponent<Collider2D>(); //коллайдер бандита
    }
    private void Update()
    {
        if (isDead) return;
        // считаем расстояние до игрока
        //float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        //используем collider2D.bounds.center вместо transform.position
        float distanceToPlayer = Vector2.Distance(collider2D.bounds.center, player.position);
        //Debug.Log($"Distance to player: {distanceToPlayer}");

        // проверяем расстояние для ближней атаки
        if (distanceToPlayer <= closeRange && !isClose)
        {
            StartCloseAttack();
            PerformAttack();
        }
        else if (distanceToPlayer > closeRange && isClose)
        {
            StopCloseAttack();
        }
       
        else if (distanceToPlayer <= attackRange && !isAttacking)
        {
            StartAttack();          
        }
        else if (distanceToPlayer > attackRange && isAttacking)
        {
            StopAttack();
        }
    }


    //  обычная атака
    private void StartAttack()
    {
        isAttacking = true;
        animator.SetBool("isAttacking", true); 

        Debug.Log("Bandit starts attacking!");
    }

    private void StopAttack()
    {
        isAttacking = false;
        animator.SetBool("isAttacking", false);        
        Debug.Log("Bandit stops attacking");
    }

    //  ближняя атака
    private void StartCloseAttack()
    {
        isClose = true;
        animator.SetBool("isClose", true); 
        Debug.Log("Bandit starts close attack!");
    }

    private void StopCloseAttack()
    {
        isClose = false;
        animator.SetBool("isClose", false); 
        Debug.Log("Bandit stops close attack");
    }

    private void PerformAttack()
    {
        // звук атаки меча
        if (swordAttackSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(swordAttackSound);
            Debug.Log("Sword attack sound played!");
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip is missing!");
        }
        // если игрок в радиусе атаки
        Collider2D[] hits = Physics2D.OverlapCircleAll(collider2D.bounds.center, attackRange);
        foreach (Collider2D hit in hits)
        {
            if (hit.TryGetComponent<Player>(out Player player))
            {
                player.ReduceHearts(attackDamage); // -- количество жизней
                Debug.Log($"Player takes {attackDamage} damage!");
            }
        }
    }

    public void TakeDamage(float damage)
    {
        damage= 25f;    
        if (isDead) return; 

        health -= damage; 
        Debug.Log($"Bandit takes {damage} damage, health: {health}");

        if (bulletHitSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(bulletHitSound);
        }
        // анимация урона
        animator.SetTrigger("Hurt");

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true; 

        animator.SetTrigger("Death"); 

        //чтобы бандит больше не реагировал на столкновения
        collider2D.enabled = false;

        // уничтожаем  через 2 с
        Destroy(gameObject, 2f);
    }

}