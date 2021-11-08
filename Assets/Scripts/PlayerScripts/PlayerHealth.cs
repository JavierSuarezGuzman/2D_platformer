using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;

    private bool hit = true;

    public GameObject flash;

    public Slider slider;
    public SpriteRenderer playerSpr;

    public Color collideColor, collideColor2;

    public AudioClip axeHit;

    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(slider.value > health)
        {
            slider.value -= .25f; //this will be move it slowly
        }
        else
        {
            slider.value += .25f;
        }


        if (health < 1 && !anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerDeath") || transform.position.y < -3)
        {
            //print("Death");
            //anim.SetTrigger("Death");
            StartCoroutine(PlayersDeath());
        }
    }

    IEnumerator PlayersDeath()// aquí el profe se le raneó la animación de muerte y cayó en loop, a mi no me pasó así que comentaré sus modificaciones
    {
        anim.SetTrigger("Death"); //anim.SetTrigger("Death", true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<PlayerAttack>().enabled = false;
        yield return new WaitForSeconds(2.5f);
        //yield return new WaitForSeconds(.1f);
        //anim.SetTrigger("Death", false);
        //yield return new WaitForSeconds(2.4f);

        //restart the level v
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void TakeDamage(int damage)
    {
        if(hit)
        {
            StartCoroutine(PlayerHit());
            health -= damage;
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "FireBallTag")
        {
            TakeDamage(15);
            Destroy(target.gameObject);
        }

        if (target.tag == "HealthPotionTag")
        {
            Destroy(target.gameObject);
            health += 30;
        }
    }


    IEnumerator PlayerFlash()
    {
        for (int i = 0; i < 2; i++)
        {
            playerSpr.color = collideColor;
            yield return new WaitForSeconds(.1f);
        }
        for (int i = 0; i < 4; i++)
        {
            playerSpr.color = collideColor2;
            yield return new WaitForSeconds(.1f);
            playerSpr.color = Color.white;
            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator PlayerHit()
    {
        SoundManager.instance.PlaySoundFx(axeHit, 2f);
        FindObjectOfType<CameraShake>().ShakeItMedium();
        flash.SetActive(true);
        hit = false;
        StartCoroutine(PlayerFlash());
        yield return new WaitForSeconds(1.3f);
        hit = true;
        flash.SetActive(false);
    }
}
