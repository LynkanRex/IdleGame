using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchasableProductionUnitScript : MonoBehaviour
{
    
    public PurchasableProduct purchasableProduct;
    public Text goldAmountText;
    public Text purchaseButtonLabel;
    float elapsedTime;

    public void SetUp(PurchasableProduct purchasableProduct) {
        this.purchasableProduct = purchasableProduct;
        this.gameObject.name = purchasableProduct.productName;
        this.purchaseButtonLabel.text = $"Purchase {purchasableProduct.productName}";
    }
    
    private Gold _gold;
    
    private int TotalCost
    {
        get
        {
            return ((this.purchasableProduct.productCost * this.ProductAmount) / 10) + this.purchasableProduct.productCost;
        }   
    }
    
    public int ProductAmount {
        get => PlayerPrefs.GetInt(this.purchasableProduct.productName, 0);
        set {
            PlayerPrefs.SetInt(this.purchasableProduct.productName, value);
            UpdateGoldPressAmountLabel();
        }
    }
    
    
    void UpdateGoldPressAmountLabel() {
        this.goldAmountText.text = this.ProductAmount.ToString($"0 {this.purchasableProduct.productName}");
    }
    
    void UpdateGoldPressButtonLabel()
    {
        this.purchaseButtonLabel.text = TotalCost.ToString($"Buy {this.purchasableProduct.productName}: 0 Gold");
    }
    
    void Start() {
        _gold = FindObjectOfType<Gold>();
        UpdateGoldPressAmountLabel();
        UpdateGoldPressButtonLabel();
    }

    void Update() {
        this.elapsedTime += Time.deltaTime;
        if (this.elapsedTime >= this.purchasableProduct.productProductionTime) {
            ProduceGold();
            this.elapsedTime -= this.purchasableProduct.productProductionTime; // DO NOT SET TO ZERO HERE
        }
        

        if (_gold.GoldAmount < TotalCost)
        {
            purchaseButtonLabel.color = Color.red;
        }
        else
        {
            purchaseButtonLabel.color = Color.black;
        }
        
    }
    
    
    void ProduceGold() {
        //var gold = FindObjectOfType<Gold>();
        _gold.GoldAmount += this.purchasableProduct.productProductionAmount * this.ProductAmount;
    }

    public void BuyGoldPress() {
        //var gold = FindObjectOfType<Gold>();
        if (_gold.GoldAmount >= this.TotalCost) {
            _gold.GoldAmount -= this.TotalCost;
            this.ProductAmount += 1;

            UpdateGoldPressButtonLabel();
        }
    }
}
