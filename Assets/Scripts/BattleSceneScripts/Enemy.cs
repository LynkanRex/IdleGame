using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    bool HasTarget => GetComponent<Target>() != null;
    
    private bool isSpawned = false;
    public int goldValue = 7;

    // Update is called once per frame
    void Update()
    {
        if (!this.HasTarget) {
            var hero = FindObjectOfType<Hero>();
            if (hero != null) {
                var target = this.gameObject.AddComponent<Target>();
                target.value = hero.gameObject;
            }
        }
    }

    //
    // private void SpawnEnemy(int value)
    // {
    //     this.lifePoints = value;
    //     this.isSpawned = true;
    //     actions.enabled = true;
    // }
}
