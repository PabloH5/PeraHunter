using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotauroScript : MonoBehaviour
{
    public GameObject player;
    public int healthNow;
    public int maxHealth = 50;
    public HealtBar healtBar;
    public float speed;
    private float distance;
    public bool inmune = false;
    public SceneController SceneController;
    public GameObject enemySpawn;
    [SerializeField]
    Transform[] waypoint;


    public GameObject subditos;

    int waypointIndex = 0;
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        healthNow = maxHealth;
        healtBar.gameObject.SetActive(true);
        healtBar.SetMaxHealth(maxHealth);
        enemySpawn.SetActive(false);

    }
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        // Debug.Log("" + distance);

        if (healthNow == 25)
        {
            inmune = true;
            transform.position = Vector2.MoveTowards(transform.position, waypoint[waypointIndex].transform.position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, waypoint[waypointIndex].transform.position) < 0.1f)
            {
                animator.SetBool("isWait", true);
                animator.SetBool("isAttack1", false);
                animator.SetBool("isAttack2", false);
                animator.SetBool("isWalk", false);
                subditos.SetActive(true);
                if (SceneController.currentScore() >= 96)
                {
                    healthNow = 24;
                    inmune = false;
                    speed = 0.8f;
                    animator.SetBool("isWait", false);
                    animator.SetBool("isWalk", true);
                    enemySpawn.SetActive(true);


                    // speed = speed * 2;
                    Vector2 direccion = player.transform.position - transform.position;
                    transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
                }
            }

        }
        else
        {
            if (distance >= 0.5 && distance <= 0.8)
            {
                animator.SetBool("isAttack1", true);
            }
            else
            {
                animator.SetBool("isAttack1", false);
                if (distance >= 0.0 && distance <= 0.5)
                {
                    // Invoke(nameof(Attack2), 1.0f);
                    animator.SetBool("isAttack2", true);
                }
                else
                {
                    animator.SetBool("isAttack2", false);
                }
            }
            Vector2 direccion = player.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }

        if (healthNow <= 0)
        {
            animator.SetBool("isDead", true);
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * 0);
            Invoke(nameof(Delete), 1.19f);
        }
    }

    private void Delete()
    {
        Destroy(this.gameObject);
    }
    private void Attack1()
    {
        animator.SetBool("isAttack1", true);
    }
    private void Attack2()
    {
        animator.SetBool("isAttack2", true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Shoot") && inmune == false)
        {
            healthNow--;
            healtBar.SetHealth(healthNow);
        }
        if (collision.gameObject.CompareTag("Taser") && inmune == false)
        {
            healthNow--;
            healtBar.SetHealth(healthNow);
        }
    }
}
