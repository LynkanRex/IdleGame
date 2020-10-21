using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PurchasableProduct
{
    
    [SerializeField] public string productName = "";
    [SerializeField] public int productCost = 100;
    [SerializeField] public int productProductionTime = 1;
    [SerializeField] public int productProductionAmount = 1;


    public GameObject productButton;
    private int _productOwnedAmount = 0;
    
    public int ProductOwnedAmount
    {
        get => _productOwnedAmount;
        set
        {
            _productOwnedAmount = value;
        }
    }
}
