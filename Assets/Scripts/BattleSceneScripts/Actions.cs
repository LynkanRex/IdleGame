using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{

    private int damage = 5;
    public int damageUpgrades = 0;
    private float currentTime;
    [SerializeField] private float timer = 0.6f;

    [SerializeField] GameObject target;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= timer)
        {
            Attack(target);
            currentTime -= timer;
        }
    }
    
    public void Attack(GameObject target)
    {
        var totalDamage = CalculateDamage();
        
        target.SendMessage("TakeDamage", totalDamage);
        Debug.Log("Attacking: " + target + "!");
    }

    private int CalculateDamage()
    {

        var totalDamage = ((damage * damageUpgrades) / 10) + damage;
        return totalDamage;
    }
}
