using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject skeleton;

    [SerializeField]
    private float skeletonInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemys(skeletonInterval, skeleton));
    }

    private IEnumerator SpawnEnemys(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-0.5f, 0.5f), 0), Quaternion.identity);
        StartCoroutine(SpawnEnemys(interval, enemy));
    }

}
