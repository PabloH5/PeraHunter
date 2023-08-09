using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public int maxHealth = 20;
    public int healthNow;
    public HealtBar healtBar;
    private void Start()
    {
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

            healtBar.SetHealth(healthNow);
        }

        if (collision.gameObject.CompareTag("Boss1"))
        {
            healthNow = healthNow - 4;
            healtBar.SetHealth(healthNow);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bazucaso"))
        {
            healthNow = healthNow - 3;

            healtBar.SetHealth(healthNow);
        }
        if (collision.gameObject.CompareTag("OPE"))
        {
            if (healthNow >= (maxHealth - 4))
            {
                healthNow = healthNow + (maxHealth - healthNow);
                // Debug.Log("" + healthNow);
                healtBar.SetHealth(healthNow);
            }
            else
            {
                healthNow = healthNow + 5;
                // Debug.Log("" + healthNow);
                healtBar.SetHealth(healthNow);
            }
        }
    }
}

