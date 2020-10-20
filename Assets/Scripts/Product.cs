﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Product : MonoBehaviour
{
    private int[] purchaseableProducts;

    [SerializeField] public string productName = "";
    [SerializeField] int productCost = 100;
    [SerializeField] int productProductionTime = 1;
    [SerializeField] int productProductionAmount = 1;

    [SerializeField] public Text productNameText = null;
    [SerializeField] private Text productButtonText = null;
    
    public int productOwnedAmount = 0;

    private int ProductOwnedAmount
    {
        get => productOwnedAmount;
        set
        {
            productOwnedAmount = value;
            UpdateProductTextLabel();
        }
    }
    
    private Component _productComponent;
    public Component ProductComponent
    {
        get
        {
            return _productComponent;
        }
        private set
        {
            _productComponent = value;
        }
    }
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        productNameText.text = productName + ": " + productOwnedAmount;
        StartCoroutine(nameof(ProductGenerateGold));
        ProductComponent = GetComponentInParent<Gold>();
    }
    
    // Update is called once per frame
    void Update()
    {
        CanAffordProductCheck();
    }

    void CanAffordProductCheck()
    {
        var gold = GetComponentInParent<Gold>();
        if (gold.GoldAmount < productCost)
        {
            productButtonText.color = Color.red;
        }
        else
        {
            productButtonText.color = Color.black;
        }
    }

    void UpdateProductTextLabel()
    {
        productNameText.text = productName + ": " + productOwnedAmount;
    }

    public void BuyProduct()
    {
        var gold = GetComponentInParent<Gold>();
        if (gold.GoldAmount > productCost)
        {
            gold.GoldAmount -= productCost;
            ProductOwnedAmount += 1;
        }
        else
        {
            Debug.Log("Not enough gold!");
        }
    }

    IEnumerator ProductGenerateGold()
    {
        while (true)
        {
            yield return new WaitForSeconds(productProductionTime);
            
            var gold = GetComponentInParent<Gold>();
            int generatedGold = productOwnedAmount * productProductionAmount;
            gold.GoldAmount += generatedGold;
        }
    }
}
