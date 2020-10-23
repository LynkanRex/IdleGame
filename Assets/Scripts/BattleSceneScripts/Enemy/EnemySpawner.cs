using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public EnemyData EnemyData;

    public Text enemyNameLabel;
    public Text enemyHealthLabel;
    
    public void SetUp(EnemyData enemyData) {
        this.EnemyData = enemyData;
        this.gameObject.name = enemyData.name;
        this.enemyNameLabel.text = enemyData.name;
        //this.enemyHealthLabel.text = enemyData.health.ToString($"0 Hp" + " / " + "0 Hp");
    }
	
    public int EnemiesKilledAmount {
        get => PlayerPrefs.GetInt(this.EnemyData.name, 0);
        set {
            PlayerPrefs.SetInt(this.EnemyData.name, value);
            UpdateEnemyNameLabel();
        }
    }

    private void Start()
    {
        UpdateEnemyNameLabel();
    }

    void UpdateEnemyNameLabel() {
        this.enemyNameLabel.text = this.EnemyData.name;
    }

    
    void Update() {
            
    }
}
