using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldSpawner : MonoBehaviour
{
    private Text goldText;
    private Hero hero;
    
    // Start is called before the first frame update
    void Start()
    {
        hero = FindObjectOfType<Hero>();
        goldText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        this.goldText.text = hero.goldAmount.ToString("0 Gold");
    }
}
