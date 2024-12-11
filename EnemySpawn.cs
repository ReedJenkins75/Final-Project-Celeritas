using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    [SerializeField] private float spawnRate = 5f;

    [SerializeField] private GameObject[] Enemy;

    [SerializeField] private bool canSpawn = true;

    private void start()
    {
        StartCoroutine(Spawner());

    }
    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (true)
        {
            yield return wait;

            int rand = Random.Range(0, Enemy.Length);

            GameObject enemyToSpawn = Enemy[rand];

            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        }
    }
}
