using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float minSpawnDistanceFromPlayer;
    public float maxSpawnDistanceFromPlayer;
    [Space]
    public float spawnDelayPerEnemy;

    private float spawnTimer;
    private Transform player;
    private int round;
    private int maxEnemies = 2;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<SquareHealth>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {
            spawnTimer = spawnDelayPerEnemy * RandomEnemySpawn();
            maxEnemies++;
        }
    }

    private int RandomEnemySpawn()
    {
        int enemyCount = Random.Range(1, maxEnemies);

        Vector3 rndDirection = Vector3.zero;
        for (int i = 0; i < enemyCount; i++)
        {
            rndDirection = Vector3.zero;
            rndDirection.x = Random.Range(-1, 1);
            rndDirection.y = Random.Range(-1, 1);
            if (rndDirection == Vector3.zero)
            {
                rndDirection = new Vector3(0.1f, 0.1f, 0);
            }

            rndDirection.Normalize();

            float distance = Random.Range(minSpawnDistanceFromPlayer, maxSpawnDistanceFromPlayer);

            GameObject newEnemy = Instantiate(enemyPrefab, player.position + (rndDirection * distance), Quaternion.identity);
        }

        Debug.Log("spawn " + enemyCount);
        return enemyCount;
    }
}
