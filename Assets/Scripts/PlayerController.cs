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
    private Taser taser;

    // private Vector2 movement;
    private AudioSource audioSource;
    private Rigidbody2D rigidbody2D;
    private Vector2 movement;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        healthNow = maxHealth;
        healtBar.SetMaxHealth(maxHealth);
    }
    private void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        movement = new Vector2(speed * inputX, speed * inputY);

        if (Input.GetMouseButtonDown(1))
        {
            taser.Attack2();
        }

        if (healthNow <= 0)
        {
            audioSource.Pause();
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate()
    {
        rigidbody2D.velocity = movement;
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

