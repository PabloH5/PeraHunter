using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMelee : MonoBehaviour
{
    public int life = 10;
    public int points = 7;
    private float distance;

    public GameObject player;
    public SceneController sceneController;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        // Debug.Log("" + distance);
        if (distance >= 0.05 && distance <= 0.5)
        {
            animator.SetBool("isAttack", true);
        }
        else { animator.SetBool("isAttack", false); }

        if (life <= 0)
        {
            sceneController.pScore(points);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Shoot"))
        {
            life--;
        }
    }
}
