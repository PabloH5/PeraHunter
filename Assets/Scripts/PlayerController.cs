using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class PlayerController : MonoBehaviour
    {
        public float speed;
        public int maxHealth = 20;
        public int healthNow;
        public HealtBar healtBar;

        //pitola 

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




        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.gameObject.CompareTag("Enemy"))
            {
                healthNow--;

                healtBar.SetHealth(healthNow);
            }
            if (collision.gameObject.CompareTag("Boss1"))
            {
                healthNow--;
                healthNow--;
                healthNow--;
                healthNow--;
                healtBar.SetHealth(healthNow);
            }



        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("OPE"))
            {
                if (healthNow >= (maxHealth - 4))
                {
                    healthNow = healthNow + (maxHealth - healthNow);
                    Debug.Log("" + healthNow);
                    healtBar.SetHealth(healthNow);
                }
                else
                {
                    healthNow = healthNow + 5;
                    Debug.Log("" + healthNow);
                    healtBar.SetHealth(healthNow);
                }
                // healtBar.SetHealth(healthNow);
            }
        }
    }
}
