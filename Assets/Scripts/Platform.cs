using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//платформа движется между 2 точками. Временно приостановлена
public class Platform : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public Transform[] points;//массив точек
    private Vector2 startPosition;

    public float speed;
    public float radius;


    // Start is called before the first frame update
    void Start()
    {
        //startPosition = transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //rb.velocity = new Vector2(0, speed);
        //if ((transform.position.y >= startPosition.y + radius && speed > 0 ) || (transform.position.y <= startPosition.y - radius && speed < 0))
        //{
        //    speed = -speed; 
        //}
    }
}
