using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Product : MonoBehaviour
{
    private int[] purchaseableProducts;
    
    [SerializeField] string productName = "";
    [SerializeField] int productCost = 100;
    [SerializeField] int productProductionTime = 1;
    [SerializeField] int productProductionAmount = 1;

    [SerializeField] private Text productNameText = null;
    [SerializeField] private Text productButtonText = null;
    
    private int _productOwnedAmount = 0;

    private int ProductOwnedAmount
    {
        get => _productOwnedAmount;
        set
        {
            _productOwnedAmount = value;
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
        productNameText.text = productName + ": " + _productOwnedAmount;
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
        productNameText.text = productName + ": " + _productOwnedAmount;
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
            int generatedGold = _productOwnedAmount * productProductionAmount;
            gold.GoldAmount += generatedGold;
        }
    }
}
