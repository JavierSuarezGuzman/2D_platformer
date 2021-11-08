using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 200;
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        anim.SetTrigger("Hit");
        FindObjectOfType<CameraShake>().ShakeItLow();
        health -= damage;
        if (health <= 0) {
            gameObject.tag = "Untagged";
            anim.SetBool("Death", true);
        }
    }
}
