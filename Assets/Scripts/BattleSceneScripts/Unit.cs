﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PlayerLoop;

public class Unit : MonoBehaviour
{
    public float attackTime = 0.6f;
    public float damage = 5f;
    public float health = 100f;
    public float maxHealth = 100f;
    float elapsedTime;
    public Text damageTextPrefab;
    public Text goldTextPrefab;
    public Text goldPopupTarget;

    
        
    public int damageUpgrades;
    public int healthUpgrades;


    public float MAXHealth
    {
        get => PlayerPrefs.GetFloat("MaxHealth", health);
        set
        {
            maxHealth =+ value;
            PlayerPrefs.SetFloat("MaxHealth", maxHealth);
        } 
    }

    public int HealthUpgrades
    {
        get => PlayerPrefs.GetInt("HealthUpgrades", 0);
        set
        {
            healthUpgrades =+ value;
            PlayerPrefs.SetInt("HealthUpgrades", value);
        }
    }
    
    public int DamageUpgrades
    {
        get => PlayerPrefs.GetInt("DamageUpgrades", 0);
        set
        {
            damageUpgrades =+ value;
            PlayerPrefs.SetInt("DamageUpgrades", value);
        }
    }

    public int CurrentEnemy
    {
        get => PlayerPrefs.GetInt(_enemyData.name);
        set
        {
            PlayerPrefs.SetInt(_enemyData.name, value);
        }
    }
   
    

    private GameObject Target => GetComponent<Target>().value;

    private bool HasTarget => GetComponent<Target>() != null && GetComponent<Target>().Exists;

    private bool CanAttack => !this.IsChargingAttack && this.HasTarget;

    private bool IsChargingAttack => this.elapsedTime < this.attackTime;

    private bool IsDead => this.health <= 0f;
    private bool IsEnemy => GetComponent<Enemy>() != null;


    private GoldSpawner goldSpawner;
    private EnemySpawner _enemySpawner;
    private EnemyData _enemyData;


    private void Awake()
    {
        InitializeUpgrades();
    }

    private void Start()
    {
        if (this.IsEnemy)
        {

            goldSpawner = FindObjectOfType<GoldSpawner>();
            _enemySpawner = GetComponent<EnemySpawner>();
            _enemyData = _enemySpawner.EnemyData;
            this.maxHealth = _enemyData.maxHealth;
            this.health = _enemyData.health;    
        }
    }

    void Update()
    {
        UpdateTime();
        if (this.CanAttack)
        {
            Attack();
        }
    }
    
    private void UpdateTime()
    {
        this.elapsedTime += Time.deltaTime;
    }
    
    
    private void Attack()
    {
        var unit = this.Target.GetComponent<Unit>();
        var totalDamage = CalculateDamage();
        unit.TakeDamage(totalDamage);
        Debug.Log($"{this} attacks {this.Target} for {totalDamage} damage!", this);
        this.elapsedTime -= attackTime;
    }

    float CalculateDamage()
    {
        var totalDamage = ((this.damage * damageUpgrades) / 10) + damage;
        return totalDamage;
    }

    public void TakeDamage(float damage)
    {
        this.health -= damage;
        UpdateHealthText();
        
        var damageTextInstance = Instantiate(this.damageTextPrefab, this.transform);
        damageTextInstance.GetComponent<Text>().text = $"-{damage} Hp";
        
        if (IsEnemy)
        {
            _enemySpawner.CurrentEnemyHealth = this.health;
        }
        
        
        if (this.IsDead)
        {
            if (IsEnemy)
            {
                var hero = this.Target.GetComponent<Hero>();
                var enemyGoldValue = GetComponent<Enemy>().goldValue;
                hero.goldAmount += enemyGoldValue;
                
                var goldTextInstance = Instantiate(this.goldTextPrefab, this.goldSpawner.transform);
                goldTextInstance.GetComponent<Text>().text = $"+{enemyGoldValue} Gold";
                
                Debug.Log($"{this} dies, leaving {enemyGoldValue} Gold on the ground for {this.Target}!", this);
            }
            Destroy(this.gameObject);
        }
    }

    void UpdateHealthText()
    {
        if (IsEnemy)
        {
            _enemySpawner.UpdateHealthText(this.health);
        }
        else
        {
            var hero = this.GetComponent<Hero>();
            hero.UpdateHealthText(this.health);
        }
    }


    void InitializeUpgrades()
    {
        this.DamageUpgrades = this.DamageUpgrades;
        this.HealthUpgrades = this.HealthUpgrades;

        UpdateHealth();
    }
    
    public void UpdateHealth()
    {
        this.MAXHealth = this.MAXHealth;
        this.health = this.MAXHealth;
    }
}
