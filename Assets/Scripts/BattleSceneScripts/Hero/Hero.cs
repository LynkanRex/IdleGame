using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Hero : MonoBehaviour
{
    private bool HasTarget => GetComponent<Target>() != null;
    
    
    
    public int goldAmount = 0;
    
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
}
