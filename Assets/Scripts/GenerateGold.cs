using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGold : MonoBehaviour
{
    [SerializeField] int goldGainAmountPerClick = 5;

    public void CreateGold()
    {
        var _gold = GetComponentInParent<Gold>();
        _gold.GoldAmount += goldGainAmountPerClick;
    }
}
