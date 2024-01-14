using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeLaplace : MonoBehaviour
{
    public int life = 8;
    public int points = 7;
    public SceneController sceneController;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            sceneController.PScore(points);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Shoot"))
        {
            life--;
        }
        if (collision.gameObject.CompareTag("Taser"))
        {
            life -= 3;
        }
    }
}
