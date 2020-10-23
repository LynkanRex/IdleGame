using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Hero : MonoBehaviour
{

    //private float currentTime;
    //private float timer = 0.6f;

    //private Actions actions;
    //private GameObject target;

    public int maxHealth = 100;
    public int lifePoints = 100;
    public int healthUpgrades = 0;
    public int goldAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage(int damage)
    {
        this.lifePoints -= damage;
    }


    public void UpgradeHealth()
    {
        if (goldAmount >= 50)
        {
            goldAmount -= 50;
            healthUpgrades++;
        
            maxHealth = ((maxHealth * healthUpgrades) / 10) + maxHealth;
            this.lifePoints = maxHealth;
        }
    }
    
    public void UpgradeDamage()
    {
        if (goldAmount >= 50)
        {
            goldAmount -= 50;
            var actions = GetComponent<Actions>();
            actions.damageUpgrades++;
        }
    }
}
