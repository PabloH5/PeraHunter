using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrilesVida : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Shoot"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
