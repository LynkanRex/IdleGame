using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{

    private int damage = 5;
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
            currentTime = 0f;
        }
    }
    
    public void Attack(GameObject target)
    {
        target.SendMessage("TakeDamage", damage);
        Debug.Log("Attacking: " + target + "!");
    }
}
