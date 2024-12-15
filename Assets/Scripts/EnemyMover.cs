using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public Transform[] points; // массив точек движения
    public float speed;
    public float pauseDuration; 
    private int currentPointIndex;
    private bool canMove;

    void Start()
    {
        currentPointIndex = 0;
        canMove = true;
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            // направление к следующей точке
            Vector2 direction = points[currentPointIndex].position - transform.position;
            rb.velocity = direction.normalized * speed;

            // проверяем, дошли ли до текущей точки
            if (direction.magnitude <= 0.1f)
            {
                // переключаемся на следующую точку
                currentPointIndex = currentPointIndex + 1 >= points.Length ? 0 : currentPointIndex + 1;
                StartCoroutine(delay());
            }
        }
        else
        {
            rb.velocity = Vector2.zero; // остановка движения во время паузы
        }
    }

    IEnumerator delay()
    {
        canMove = false; 
        yield return new WaitForSeconds(pauseDuration); 
        canMove = true;
    }
}
