using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    private GameObject hero => GameObject.Find("Hero");
    private Hero heroGold => GetComponent<Hero>();
    private Unit statReference => GetComponent<Unit>();
    
    public void UpgradeHealth()
    {
        if (heroGold.goldAmount >= 50)
        {
            heroGold.goldAmount -= 50;

            hero.GetComponent<Unit>().healthUpgrades++;
            statReference.maxHealth = ((statReference.maxHealth * statReference.healthUpgrades) / 10) + statReference.maxHealth;
            statReference.health = statReference.maxHealth;
        }
    }
    
    public void UpgradeDamage()
    {
        if (heroGold.goldAmount >= 50)
        {
            heroGold.goldAmount -= 50;
            hero.GetComponent<Unit>().damageUpgrades++;
        }
    }
}
