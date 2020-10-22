using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchasableProductionUnitScript : MonoBehaviour
{
    
    public PurchasableProduct purchasableProduct;
    public Text goldAmountText;
    public Text purchaseButtonLabel;
    public Button upgradeButton;
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
    
    private int UpgradeCost
    {
        get
        {
            return ((this.purchasableProduct.upgradeCost * this.UpgradeAmount) / 10) + this.purchasableProduct.upgradeCost;
        }   
    }
    
    public int ProductAmount {
        get => PlayerPrefs.GetInt(this.purchasableProduct.productName, 0);
        set {
            PlayerPrefs.SetInt(this.purchasableProduct.productName, value);
            UpdateGoldPressAmountLabel();
        }
    }
    
    public int UpgradeAmount {
        get => PlayerPrefs.GetInt(this.purchasableProduct.productUpgradeName, 0);
        set {
            PlayerPrefs.SetInt(this.purchasableProduct.productUpgradeName, value);
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

        
        if (_gold.GoldAmount < UpgradeCost)
        {
            upgradeButton.image.color = Color.red;
        }
        else
        {
            upgradeButton.image.color = Color.white;
        }
        
    }
    
    
    void ProduceGold()
    {
        double upgradeBonus = 1 + (this.UpgradeAmount * .05);
        _gold.GoldAmount += (int)((this.purchasableProduct.productProductionAmount * this.ProductAmount) * upgradeBonus);
    }

    public void BuyPurchasableProduct() {
        if (_gold.GoldAmount >= this.TotalCost) {
            _gold.GoldAmount -= this.TotalCost;
            this.ProductAmount += 1;

            UpdateGoldPressButtonLabel();
        }
    }
    
    public void BuyProductUpgrade() {
        if (_gold.GoldAmount >= this.UpgradeCost) {
            _gold.GoldAmount -= this.UpgradeCost;
            this.UpgradeAmount += 1;
        }
    }
}
