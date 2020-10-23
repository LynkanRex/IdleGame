using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Unit : MonoBehaviour
{
    public float attackTime = 0.6f;
    public float damage = 5f;
    public float health = 100f;
    float elapsedTime;


    private GameObject Target => GetComponent<Target>().value;

    private bool HasTarget => GetComponent<Target>() != null && GetComponent<Target>().Exists;

    private bool CanAttack => !this.IsChargingAttack && this.HasTarget;

    private bool IsChargingAttack => this.elapsedTime < this.attackTime;

    private bool IsDead => this.health <= 0f;
    private bool IsEnemy => GetComponent<Enemy>() != null;
    
    // Update is called once per frame
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
        unit.TakeDamage(this.damage);
        Debug.Log($"{this} attacks {this.Target} for {this.damage} damage!", this);
        this.elapsedTime -= attackTime;
    }

    public void TakeDamage(float damage)
    {
        this.health -= damage;
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
}
