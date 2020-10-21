using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public Text goldText;
    private Gold _gold;

    private void Start()
    {
        _gold = GetComponentInParent<Gold>();
    }

    public void UpdateGoldTextLabel()
    {
        goldText.text = "Gold: " + _gold.GoldAmount;
    }
}
