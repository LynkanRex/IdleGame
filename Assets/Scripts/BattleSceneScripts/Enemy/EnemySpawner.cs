using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public EnemyData EnemyData;

    public void SetUp(EnemyData enemyData) {
        this.EnemyData = enemyData;
        this.gameObject.name = enemyData.name;
    }
	
    public int EnemiesKilledAmount {
        get => PlayerPrefs.GetInt(this.EnemyData.name, 0);
        set {
            PlayerPrefs.SetInt(this.EnemyData.name, value);
        }
    }
    
    void Update() {
            
    }
}
