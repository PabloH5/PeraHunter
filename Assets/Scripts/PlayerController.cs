using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public int maxHealth = 20;
    public int healthNow;
    public HealtBar healtBar;
    [SerializeField]
    Taser taser;


    private AudioSource audioSource;

    // public GameObject tasersito;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        healthNow = maxHealth;
        healtBar.SetMaxHealth(maxHealth);
    }
    private void Update()
    {
        Vector2 dir = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
        }
        dir.Normalize();
        GetComponent<Rigidbody2D>().velocity = speed * dir;

        if (Input.GetMouseButtonDown(1))
        {
            taser.Attack2();
        }

        if (healthNow <= 0)
        {
            audioSource.Pause();
            Destroy(this.gameObject);
            // this.gameObject.SetActive(false);
        }
    }
    public int vida()
    {
        return healthNow;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            healthNow--;
            audioSource.Play();
            healtBar.SetHealth(healthNow);
        }

        if (collision.gameObject.CompareTag("Boss1"))
        {
            healthNow = healthNow - 4;
            audioSource.Play();
            healtBar.SetHealth(healthNow);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            healthNow--;
            audioSource.Play();
            healtBar.SetHealth(healthNow);
        }

        if (collision.gameObject.CompareTag("Boss1"))
        {
            healthNow = healthNow - 4;
            audioSource.Play();
            healtBar.SetHealth(healthNow);
        }
        if (collision.gameObject.CompareTag("Bazucaso"))
        {
            healthNow = healthNow - 3;
            audioSource.Play();
            healtBar.SetHealth(healthNow);
        }
        if (collision.gameObject.CompareTag("OPE"))
        {
            if (healthNow >= (maxHealth - 4))
            {
                healthNow = healthNow + (maxHealth - healthNow);
                healtBar.SetHealth(healthNow);
            }
            else
            {
                healthNow = healthNow + 5;
                healtBar.SetHealth(healthNow);
            }
        }
    }
}

