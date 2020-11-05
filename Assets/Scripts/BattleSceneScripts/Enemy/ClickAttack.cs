using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAttack : MonoBehaviour
{

    [SerializeField] private float clickDamage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoClickAttack()
    {
        Debug.Log("Clicking enemy");
        var enemy = GetComponentInParent<Unit>();
        enemy.TakeDamage(clickDamage);
    }
}
