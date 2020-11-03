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

            var heroReference = hero.GetComponent<Unit>(); 
            
            heroReference.HealthUpgrades++;
            heroReference.MAXHealth = ((heroReference.MAXHealth * heroReference.HealthUpgrades) / 10 ) + heroReference.MAXHealth;
            heroReference.health = heroReference.MAXHealth;
        }
    }
    
    public void UpgradeDamage()
    {
        if (heroGold.goldAmount >= 50)
        {
            heroGold.goldAmount -= 50;
            hero.GetComponent<Unit>().DamageUpgrades++;
        }
    }
}
