using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public SceneController sceneController;

    public int life = 4;
    public int points = 1;
    public float speed;

    private float distance;

    public int Score = 0;


    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direccion = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

        if (life <= 0)
        {
            Debug.Log(" " + sceneController.pScore(points));
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
