using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Timeline;

public class Hero : MonoBehaviour
{
    private bool HasTarget => GetComponent<Target>() != null;
    public Text healthText;
    
    
    public int goldAmount = 0;


    private void Start()
    {
        var heroHealth = GetComponent<Unit>();
        this.healthText.text = $"Hero: {heroHealth.health} Hp" + " / " + $"{heroHealth.maxHealth} Hp";
    }

    void Update()
    {
        if (!this.HasTarget) {
            var enemy = FindObjectOfType<Enemy>();
            if (enemy != null) {
                var target = this.gameObject.AddComponent<Target>();
                target.value = enemy.gameObject;
            }
        }
    }
    
    public void UpdateHealthText(float healthValue)
    {
        var heroHealth = GetComponent<Unit>();
        this.healthText.text = $"Hero: {heroHealth.health} Hp" + " / " + $"{heroHealth.maxHealth} Hp";
    }
    
}
