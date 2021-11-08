using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    private Rigidbody2D rb;
    private Vector2 playerPos;

    public float force = 150;

    public AudioClip fireBallClip;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        ShootThePlayer();
    }

   
    void ShootThePlayer()
    {
        playerPos = GameObject.FindGameObjectWithTag("PlayerTag").transform.position;

        Vector2 heading = (playerPos - (Vector2)transform.position);
        float dist = heading.magnitude;
        Vector2 dir = heading / dist; //with this the fireball will be where's supposed to BE

        rb.AddForce(dir * force); // this will make the fireball go to the player 

        float angle = Mathf.Atan2(heading.y, heading.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);

        SoundManager.instance.PlaySoundFx(fireBallClip, .3f);

        Destroy(gameObject, 4);
    }

}
