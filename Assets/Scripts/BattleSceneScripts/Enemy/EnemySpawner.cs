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
    public Sprite artwork;

    public Image imageRef;
    
    public void SetUp(EnemyData enemyData) {
        this.EnemyData = enemyData;
        this.gameObject.name = enemyData.name;
        this.enemyNameLabel.text = enemyData.name;
        this.enemyHealthLabel.text = CurrentEnemyHealth.ToString($"0 Hp" + " / " + $"{enemyData.maxHealth} Hp");
        this.artwork = enemyData.artwork;
        //this.enemyHealthLabel.text = enemyData.health.ToString($"0 Hp" + " / " + $"{enemyData.maxHealth} Hp");
    }
    
    public float CurrentEnemyHealth
    {
        get => PlayerPrefs.GetFloat("CurrentEnemyHealth", EnemyData.maxHealth);
        set
        {
            PlayerPrefs.SetFloat("CurrentEnemyHealth", value);
            UpdateHealthText(value);
        }
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
        InstantiateStats();
    }

    
    void Update() {
      
    }

    void InstantiateStats()
    {
        UpdateEnemyNameLabel();
        UpdateEnemySprite();
        UpdateEnemyHealth();
    }
    
    void UpdateEnemyNameLabel() {
        this.enemyNameLabel.text = this.EnemyData.name;
    }
    
    void UpdateEnemySprite()
    {
        //imageRef = GetComponentInChildren<Image>();
        imageRef.sprite = this.EnemyData.artwork;
    }
    
    void UpdateEnemyHealth()
    {
        this.CurrentEnemyHealth = this.CurrentEnemyHealth;
        this.enemyHealthLabel.text = CurrentEnemyHealth.ToString($"0 Hp" + " / " + $"{EnemyData.maxHealth} Hp");
    }


    public void UpdateHealthText(float healthValue)
    {
        this.enemyHealthLabel.text = healthValue.ToString($"0 Hp" + " / " + $"{EnemyData.maxHealth} Hp");
    }

}
