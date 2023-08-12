using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public SceneController sceneController;
    [SerializeField]
    private GameObject heart;

    public int life = 4;
    public int points = 1;
    public float speed;

    private float distance;
    private float random = 0;
    public int Score = 0;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (player == null)
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direccion = player.transform.position - transform.position;

            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

            if (life <= 0)
            {
                sceneController.pScore(points);
                random = Random.Range(0.0f, 1.1f);
                if (random >= 0.75)
                {
                    heart = Instantiate(heart, this.transform.position, Quaternion.identity);
                }
                Destroy(this.gameObject);
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Shoot"))
        {
            audioSource.Play();
            life--;

        }
        if (collision.gameObject.CompareTag("Taser"))
        {
            audioSource.Play();
            life = life - 4;
        }
    }
}
