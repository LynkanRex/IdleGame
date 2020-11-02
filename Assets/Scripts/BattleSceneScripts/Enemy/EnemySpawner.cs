using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
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
        this.enemyHealthLabel.text = enemyData.health.ToString($"0 Hp" + " / " + $"{enemyData.maxHealth} Hp");
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

    
    void Update() {
      
    }

    void UpdateEnemyNameLabel() {
        this.enemyNameLabel.text = this.EnemyData.name;
    }


    public void UpdateHealthText(float healthValue)
    {
        this.enemyHealthLabel.text = healthValue.ToString($"0 Hp" + " / " + $"{EnemyData.maxHealth} Hp");
    }

}
