using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform2 : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    public float speed;
    public Transform[] points;//массив точек
    public float pauseDuration;
    private int index;
    private bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        canMove = true;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (canMove)
        {
            Vector2 direction = points[index].position - transform.position;
            rb.velocity = direction.normalized * speed;//normalized гарантирует, что между всеми точками мы будем двигаться с постоянной скоростью

            if (direction.magnitude <= 0.1f)
            {
                //index = index + 1 >= points.Length ? 0 : index + 1; //переход по точкам, которые заданы в массиве points в инспекторе

                // вычисляем новый индекс, отличный от текущего
                int newIndex;
                do
                {
                    newIndex = Random.Range(0, points.Length);
                } while (newIndex == index);

                index = newIndex; 
                StartCoroutine(delay());
            }
        }
        else
        {
        rb.velocity = Vector2.zero;
        }
    }
    IEnumerator delay()
    {
        canMove = false;
        yield return new WaitForSeconds(2); //в этот момент происходит задержка 
        canMove = true;
    }
}
