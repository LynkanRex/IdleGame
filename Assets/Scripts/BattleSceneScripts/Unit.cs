using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Unit : MonoBehaviour
{
    public float attackTime = 0.6f;
    public float damage = 5f;
    public float health = 100f;
    public float maxHealth = 100f;
    float elapsedTime;

    public int healthUpgrades;
    public int damageUpgrades;


    private GameObject Target => GetComponent<Target>().value;

    private bool HasTarget => GetComponent<Target>() != null && GetComponent<Target>().Exists;

    private bool CanAttack => !this.IsChargingAttack && this.HasTarget;

    private bool IsChargingAttack => this.elapsedTime < this.attackTime;

    private bool IsDead => this.health <= 0f;
    private bool IsEnemy => GetComponent<Enemy>() != null;


    private EnemySpawner _enemySpawner;
    private EnemyData _enemyData;
    
    private void Start()
    {
        if (this.IsEnemy)
        {
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
        if (IsEnemy)
        {
            UpdateHealthText();
        }
        
        
        if (this.IsDead)
        {
            if (IsEnemy)
            {
                var hero = this.Target.GetComponent<Hero>();
                var enemyGoldValue = GetComponent<Enemy>().goldValue;
                hero.goldAmount += enemyGoldValue;
                Debug.Log($"{this} dies, leaving {enemyGoldValue} Gold on the ground for {this.Target}!", this);
            }
            Destroy(this.gameObject);
        }
    }

    void UpdateHealthText()
    {
        _enemySpawner.UpdateHealthText(this.health);
    }
}
