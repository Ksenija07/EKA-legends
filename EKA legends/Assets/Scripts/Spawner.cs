using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public float spawnInterval = 30f;
    public Vector3 spawnAreaMin = new Vector3(-10f, 0f, -10f);
    public Vector3 spawnAreaMax = new Vector3(10f, 0f, 10f);
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float z = Random.Range(spawnAreaMin.z, spawnAreaMax.z);
        float y = spawnAreaMin.y;

        Vector3 spawnPosition = new Vector3(x, y, z);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
