using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject heart;

    [SerializeField]
    private float heartInterval = 1.8f;
    void Start()
    {
        StartCoroutine(SpawnEnemys(heartInterval, heart));
    }
    private IEnumerator SpawnEnemys(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-8.0f, 0.5f), 0), Quaternion.identity);
        newEnemy.SetActive(true);
        StartCoroutine(SpawnEnemys(interval, enemy));
    }
}
