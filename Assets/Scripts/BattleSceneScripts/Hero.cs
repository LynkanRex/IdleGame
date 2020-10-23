using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Hero : MonoBehaviour
{

    //private float currentTime;
    //private float timer = 0.6f;

    private Actions actions;
    //private GameObject target;

    public int lifePoints = 100;
    public int goldAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        // currentTime += Time.deltaTime;
        // if (currentTime >= timer)
        // {
        //     actions.Attack(target);
        //     currentTime = 0f;
        // }
    }


    public void TakeDamage(int damage)
    {
        this.lifePoints -= damage;
    }
}
