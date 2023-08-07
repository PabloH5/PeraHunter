using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject skeleton;

    [SerializeField]
    private float skeletonInterval = 1.8f;

    [SerializeField]
    private GameObject goblin;

    [SerializeField]
    private float goblinInterval = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemys(skeletonInterval, skeleton));
        StartCoroutine(SpawnEnemys(goblinInterval, goblin));
    }

    private IEnumerator SpawnEnemys(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-0.5f, 0.5f), 0), Quaternion.identity);
        newEnemy.SetActive(true);
        StartCoroutine(SpawnEnemys(interval, enemy));
    }

}
