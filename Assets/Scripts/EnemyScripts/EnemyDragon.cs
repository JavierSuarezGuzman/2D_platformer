using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDragon : MonoBehaviour
{

    public float speed, bound;
    private float coolDown;

    private bool up;

    private Animator anim;
    private Transform player;

    public GameObject fireBall;
    public Transform fireBallPos;

    private Rigidbody2D rb;
    private bool death;

    private void Awake()
    {
        player = GameObject.Find("Assassin").transform;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        bound = transform.position.y;
    }


    void Update()
    {
        if (death) return;


        if (Vector2.Distance(player.position, transform.position)<= 4 && coolDown == 0)
        {
            coolDown = 2.5f;
            anim.SetTrigger("Attack");
        }
        else if(Vector2.Distance(player.position, transform.position) > 4)
        {
            coolDown = 1.5f; //I don't want to attack as soon as he sees him
        }
        Movement();
        CoolDownTimer();
    }

    void Attack() //actual attack
    {
        Instantiate(fireBall, fireBallPos.position, Quaternion.identity);
    }

    void Movement()
    {
        if (up)
        {
            Vector3 pos = transform.position;
            pos.y += speed;
            transform.position = pos;
            if (transform.position.y > bound + 0.13f) up = false; // if you want to increase the vertical movemetn (y) increase the 0.13f
        }
        else //for downwards
        {
            Vector3 pos = transform.position;
            pos.y -= speed;
            transform.position = pos;
            if (transform.position.y < bound - 0.13f) up = true;
        }

        if (transform.position.x < player.transform.position.x) transform.localScale = new Vector3(1, 1, 1);
        if (transform.position.x > player.transform.position.x) transform.localScale = new Vector3(-1, 1, 1);
    }

    void CoolDownTimer()
    {
        if(coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }

        if (coolDown < 0)
        {
            coolDown = 0;
        }
    }

    void Death()
    {
        rb.isKinematic = false;
        death = true;
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "GroundTag")
        {
            rb.isKinematic = true;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
