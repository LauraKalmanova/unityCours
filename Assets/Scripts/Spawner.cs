using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject entityPrefab;
    [SerializeField] private float spawnInterval = 1;
    [SerializeField] private int maxSpawnCount = 5;

    private float lastSpawnTime;
    private int spawnCount;

    private void Update()
    {
        if(lastSpawnTime >= spawnInterval && spawnCount < maxSpawnCount)
        {
            lastSpawnTime = 0;
            spawnCount++;
            var instance = Instantiate(entityPrefab, transform);
            instance.GetComponent<Enemy>().OnHit += OnEnemyHit;
        }
        lastSpawnTime += Time.deltaTime;
    }

    private void OnEnemyHit(Enemy enemy)
    {
        Debug.Log(enemy);
    }

    public void EnemyDestroyed()
    {
        spawnCount--;
    }
}
