using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyToSpawn;

    public float timeToSpawn;
    public float spawnCounter;

    public Transform minSpawn, maxSpawn;

    private Transform target;

    private float despawnDistance;

    private List<GameObject> spawnedEnemies = new List<GameObject>();

    public int checkPerFrame;

    private int enemyToCheck;


    private void Start()
    {
        spawnCounter = timeToSpawn;

        target = GameObject.FindGameObjectWithTag("Player").transform;

        despawnDistance = Vector2.Distance(transform.position, maxSpawn.position) + 4f;
    }

    private void Update()
    {
        spawnCounter -= Time.deltaTime;
        if (spawnCounter <= 0)
        {
            spawnCounter = timeToSpawn;
            GameObject newEnemy = Instantiate(enemyToSpawn, SelectSpawnPoint(), Quaternion.identity);
            spawnedEnemies.Add(newEnemy);
        }

        if (target != null)
        {
            transform.position = target.position;
        }

        for (int i = 0; i < checkPerFrame && enemyToCheck < spawnedEnemies.Count; i++, enemyToCheck++)
        {
            GameObject enemy = spawnedEnemies[enemyToCheck];
            if (enemy != null)
            {
                if (Vector2.Distance(transform.position, enemy.transform.position) > despawnDistance)
                {
                    Destroy(enemy);
                    spawnedEnemies.RemoveAt(enemyToCheck--);
                }
            }
            else
            {
                spawnedEnemies.RemoveAt(enemyToCheck--);
            }
        }

        if (enemyToCheck >= spawnedEnemies.Count)
        {
            enemyToCheck = 0; // Reset the counter after all enemies are checked
        }
    }


    public Vector2 SelectSpawnPoint() 
    {
        Vector2 spawnPoint = Vector2.zero;
        bool spawnVerticalEdge = Random.Range(0f, 1f) > 0.5f;
        if (spawnVerticalEdge)
        {
            spawnPoint.y = Random.Range(minSpawn.position.y, maxSpawn.position.y);

            if (Random.Range(0f, 1f) > .5f)
            {
                spawnPoint.x = minSpawn.position.x;
            }
            else
            {
                spawnPoint.x = maxSpawn.position.x;
            }
        }
        else 
        {
            spawnPoint.x = Random.Range(minSpawn.position.x, maxSpawn.position.x);

            if (Random.Range(0f, 1f) > .5f)
            {
                spawnPoint.y = minSpawn.position.y;
            }
            else
            {
                spawnPoint.y = maxSpawn.position.y;
            }
        }


        return spawnPoint;
    }

}
