using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazucaso : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float speed;
    [Range(1, 10)]
    [SerializeField] private float lifeTime = 2.0f;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direccion = player.transform.position - transform.position;
        rb.velocity = new Vector2(direccion.x, direccion.y).normalized * speed;
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 direccion = player.transform.position - transform.position;
            rb.velocity = new Vector2(direccion.x, direccion.y).normalized * 0;
            animator.SetBool("BUM", true);
            Invoke(nameof(Delete), 0.25f);
        }
    }

    private void Delete()
    {
        Destroy(this.gameObject);
    }
}
