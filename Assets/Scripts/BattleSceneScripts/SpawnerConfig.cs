using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerConfig : MonoBehaviour
{
    public EnemyData[] enemyDatas;
    public Transform spawnPointParent;
    public GameObject enemyUnitPrefab;

    void Start() {
        foreach (var enemyData in this.enemyDatas) {
            var instance = Instantiate(this.enemyUnitPrefab, this.spawnPointParent);
            instance.GetComponent<EnemySpawner>().SetUp(enemyData);
        }
    }
}
