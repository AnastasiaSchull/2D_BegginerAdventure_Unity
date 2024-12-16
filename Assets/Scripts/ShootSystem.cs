using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSystem : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Bomb bombPrefab;

    public KeyCode bombKey;
    public float bombForce;
    public float delay;


    private float lastShootTime;
    private float bombMultiply;

    //GetMouseButtonDown(0) 0-левая кнопка мыши,1-правая ,2 центр
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && (Time.time - lastShootTime > delay))
        {
            Shoot();
        }

        if (Input.GetKeyUp(bombKey))
        {
            SootBomb();
        }

        if (Input.GetKey(bombKey))
        {
            bombMultiply += Time.deltaTime;
        }
    }

    // spawn пули
    private void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        bullet.speed *= Mathf.Abs(transform.lossyScale.x) / transform.lossyScale.x;
        lastShootTime = Time.time;
    }

    private void SootBomb()
    {
        Bomb bomb = Instantiate(bombPrefab, bulletSpawn.position, Quaternion.identity);
        bombMultiply = Mathf.Clamp(bombMultiply, 0, 2);//2 это max bombMultiply
        bomb.LoadBomb(new Vector2(1, 1) * bombForce * (1 + bombMultiply));//Vector2(1, 1)  ==45 градусов
        bombMultiply = 0;
    }
}
