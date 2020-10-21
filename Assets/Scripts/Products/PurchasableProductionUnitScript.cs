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
    
    void Start() {
        UpdateGoldPressAmountLabel();
    }

    void Update() {
        this.elapsedTime += Time.deltaTime;
        if (this.elapsedTime >= this.purchasableProduct.productProductionTime) {
            ProduceGold();
            this.elapsedTime -= this.purchasableProduct.productProductionTime; // DO NOT SET TO ZERO HERE
        }
    }
    
    
    void ProduceGold() {
        var gold = FindObjectOfType<Gold>();
        gold.GoldAmount += this.purchasableProduct.productProductionAmount * this.ProductAmount;
    }

    public void BuyGoldPress() {
        var gold = FindObjectOfType<Gold>();
        if (gold.GoldAmount >= this.purchasableProduct.productCost) {
            gold.GoldAmount -= this.purchasableProduct.productCost;
            this.ProductAmount += 1;
        }
    }
}
