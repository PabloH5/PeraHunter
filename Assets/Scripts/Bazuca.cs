using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazuca : MonoBehaviour
{
    public GameObject bazucasoPrefab;
    public Transform bazuPoss;

    public float timer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            timer = 0;
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(bazucasoPrefab, bazuPoss.position, Quaternion.identity);
    }
}
