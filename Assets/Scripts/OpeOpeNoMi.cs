using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeOpeNoMi : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float lifeTime = 60f;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Destroy(this.gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
