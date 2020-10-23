using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Hero : MonoBehaviour
{
    private bool HasTarget => GetComponent<Target>() != null;
    
    // public int maxHealth = 100;
    // public int lifePoints = 100;
    // public int healthUpgrades = 0;
    public int goldAmount = 0;

    // Update is called once per frame
    void Update()
    {
        if (!this.HasTarget)
        {
            var enemy = FindObjectOfType<Enemy>();
            if (enemy != null)
            {
                var target = this.gameObject.AddComponent<Target>();
                target.value = enemy.gameObject;
            }
        }
    }


    public void UpgradeHealth()
    {
        if (goldAmount >= 50)
        {
            goldAmount -= 50;
            // healthUpgrades++;
            //
            // maxHealth = ((maxHealth * healthUpgrades) / 10) + maxHealth;
            // this.lifePoints = maxHealth;
        }
    }
    
    public void UpgradeDamage()
    {
        if (goldAmount >= 50)
        {
            goldAmount -= 50;
            // var actions = GetComponent<Actions>();
            // actions.damageUpgrades++;
        }
    }
}
