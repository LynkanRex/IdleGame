using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateGold : MonoBehaviour
{
    public int goldAmount;
    public Text goldText;

    // Start is called before the first frame update
    void Start()
    {
        goldAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = "Gold: " + goldAmount;
    }
}
