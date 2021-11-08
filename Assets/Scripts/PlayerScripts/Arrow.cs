using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 0.05f;
    private bool right;

    public AudioClip connect;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("PlayerTag").transform.localScale.x > 0)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            right = true;

        }
        else
        {
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
            right = false;
        }

        Destroy(gameObject, 3);
    }


    void Update()
    {
        if (right)
            transform.Translate(Vector2.right * speed);
        else
            transform.Translate(Vector2.left * speed);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "EnemyTag")
        {
            Destroy(gameObject);
            target.GetComponent<EnemyHealth>().TakeDamage(20);
            SoundManager.instance.PlaySoundFx(connect, .5f);
        }
    }
}
