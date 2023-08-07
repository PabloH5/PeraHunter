using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitola : MonoBehaviour
{
    [SerializeField] private GameObject balasoPrefab;
    [SerializeField] private Transform firingPoint;
    private Rigidbody2D rb;
    public float speed;
    private float mx;
    private float my;
    private Vector2 mousePoss;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");
        my = Input.GetAxisRaw("Vertical");
        mousePoss = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = Mathf.Atan2(mousePoss.y - transform.position.y, mousePoss.x -
        transform.position.x) * Mathf.Rad2Deg - 90f;

        transform.localRotation = Quaternion.Euler(0, 0, angle);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        Instantiate(balasoPrefab, firingPoint.position, firingPoint.rotation);
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(mx, my).normalized * speed;
    }
}
