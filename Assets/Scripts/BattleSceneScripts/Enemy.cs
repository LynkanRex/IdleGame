using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private bool isSpawned = false;
    public Actions actions;

    public int maxLifePoints = 40;
    public int lifePoints = 40;
    public int goldValue = 7;

    void Awake()
    {
        SpawnEnemy(this.maxLifePoints);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpawned)
        {
            return;
        }
        else
        {
            SpawnEnemy(this.maxLifePoints);
        }
    }


    private void SpawnEnemy(int maxLifePoints)
    {
        this.lifePoints = maxLifePoints;
        this.isSpawned = true;
        actions.enabled = true;
    }
    
    public void TakeDamage(int damage)
    {
        this.lifePoints -= damage;
        if (this.lifePoints <= 0)
        {
            var hero = GameObject.Find("Hero");
            var heroStats = hero.GetComponent<Hero>();
            heroStats.goldAmount += goldValue;
            this.isSpawned = false;
            actions.enabled = false;
        }
    }
}
