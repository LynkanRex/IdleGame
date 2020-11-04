using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class SpawnerConfig : MonoBehaviour
{
    public EnemyData[] enemyDatas;
    public Transform spawnPointParent;
    public GameObject enemyUnitPrefab;

    private bool noEnemies;
    
    
    void Start()
    {
        
    }


    private void Update()
    {
        noEnemies = FindObjectOfType<Enemy>();
        
        if (!noEnemies)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        var index = Random.Range(0, enemyDatas.Length);
        var instance = Instantiate(this.enemyUnitPrefab, this.spawnPointParent);
        instance.GetComponent<EnemySpawner>().SetUp(enemyDatas[index]);

        var currentHealthReference = instance.GetComponent<EnemySpawner>().CurrentEnemyHealth;
        currentHealthReference = currentHealthReference;
    }
}
