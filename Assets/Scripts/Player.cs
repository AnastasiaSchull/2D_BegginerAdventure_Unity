using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour     
{
    public event Action<float> onCoinsChanged; 
    
    [SerializeField] private Rigidbody2D rb;//несмотря на то, что поле приватное , благодаря [SerializeField] , мы в инспекторе сможем настроить его
    [SerializeField] private Collider2D Collider2D;

    [SerializeField] private float checkRad;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;

    [SerializeField] Animator animator;
    public Inventory inventory;

    public float speed;//публичные отображаются в инспекторе
    public KeyCode jumpKey;//клавиша прыжка
    public float jumpForce;//сила прыжка

    private float move;
    private bool isGrounded; //чтоб запретить подпрыгивать , если в воздухе
    private bool isRunning;


    private int coins = 0;
    private int hearts = 3; // кол-во жизней
    private int crystals = 0;

    // max кол-во жизней
    private int maxHearts = 10;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");//считываем нажатие клавиш
                                              //Debug.Log(Input.GetAxisRaw("Horizontal"));//команда возвращает -1 0 1 ( если кнопка нажата <-,не нажата или  -> )
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce);//Vector2.up == Vector2(0,1) //прыжки эт тоже физика поэтому лучше делать в FixedUpdate()
           // isGrounded = false; // 1 способ          
        }
        /*1 вариант
        if (move != 0)
        {
            animator.SetBool("isRunning", true);
        }*/

        //2 вариант 
         isRunning = move != 0?true:false;
         animator.SetBool("isRunning", isRunning);
    }

    private void FixedUpdate()//в этом методе должны присходить перемещения
    {
        rb.velocity = new Vector2(speed*move, rb.velocity.y);//speed это по оси X , а  rb.velocity.y - это V по умолчанию, если поставить 0 , то это мы принудительно останавливаем

#region Flip Logic Experiments 
        // рабочий поворот персонажа. Крош-персонаж без анимации
        //if (rb.velocity.x > 0) // eсли движение ->
        //{
        //    transform.localScale = new Vector3(1, 1, 1);
        //}
        //else if (rb.velocity.x < 0) // eсли движение <-
        //{
        //    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        //}


        //!с этим решением некорректно работал бег Мага влево
        //if (rb.velocity.x > 0) //  ->
        //{
        //    transform.localScale = new Vector3(transform.localScale.x , transform.localScale.y, transform.localScale.z);
        //}
        //else if (rb.velocity.x < 0) // <-
        //{
        //    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        //}
        #endregion

        // смена направления Мага
        //Mathf.Abs (аbsolute) возвращает модуль числа
        if (move > 0 && transform.localScale.x < 0) // ->
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (move < 0 && transform.localScale.x > 0) // <-
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        // 2 способ
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRad, groundMask);//true если обьекты попадают в указанную сферу, в данный момент это наш персонаж попадает в сферу

        isRunning = move != 0 ? true : false;
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isGrounded", isGrounded);
    }

#region Collision Events
    //1 способ. сработает, когда коллайдер персонажа столкнется с другим коллайдером
    //OnCollisionExit2D сработает когда разъединятся 2 коллайдера
    //OnCollisionStay2D - будет срабатывать каждый игровой кадр, пока коллайдеры соприкосаются

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }*/
    #endregion

    private void OnDrawGizmos()//этот метод действует в инспекторе, не в игре
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(groundCheck.position, checkRad);

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.TryGetComponent(out ICollideble collideble))
        {
            collideble.Collide(this);
        }
    }

#region Coin, Heart, and Crystal Methods
    public void AddCoins(int amount)
    {
        coins += amount;
        Debug.Log("Coins: " + coins);
        onCoinsChanged.Invoke(coins);
    }

    public void AddHearts(int amount)
    {
        if (hearts < maxHearts) // проверим чтоб не было переполнено
        {
            hearts += amount;
            if (hearts > maxHearts)
                hearts = maxHearts;

            Debug.Log("Hearts: " + hearts);
        }
        else
        {
            Debug.Log("Hearts are full!");
        }
    }

    public void AddCrystals(int amount)
    {
        crystals += amount;
        Debug.Log("Crystals: " + crystals);
    }

    public void ReduceHearts(int damage)
    {
        hearts -= damage;

        if (hearts <= 0)
        {
            hearts = 0;
        }
        Debug.Log($"Player hearts remaining: {hearts}");
    }

    #endregion 
}
