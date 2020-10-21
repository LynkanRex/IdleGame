using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Product : MonoBehaviour
{

    //public PurchasableProduct[] purchasableProduct;
    public GameObject buttonCanvas;


    // Start is called before the first frame update
    void Start()
    {
        GenerateProductButtons();

        
        //productNameText.text = productName + ": " + productOwnedAmount;
        //StartCoroutine(nameof(ProductGenerateGold));
    }

    void GenerateProductButtons()
    {
        // for (var i = 0; i < purchasableProduct.Length; i++)
        // {
        //     var myGameObject = Instantiate(purchasableProduct[i].productButton) as GameObject;
        //
        //     myGameObject.transform.SetParent(buttonCanvas.transform);
        //     
        //     var myView = myGameObject.GetComponent<ConfigurableProductView>();
        //     myView.productButtonText.text = purchasableProduct[i].productName;
        // }
    }
    
    // Update is called once per frame
    void Update()
    {
        CanAffordProductCheck();
    }

    void CanAffordProductCheck()
    {
         var gameCanvas = GameObject.Find("GameCanvas");
         var gold = gameCanvas.GetComponentInParent<Gold>();
         if (gold.GoldAmount < purchasableProduct[0].productCost)
         {
             purchasableProduct[0].productView.productButtonText.color = Color.red;
         }
         else
         {
             purchasableProduct[0].productButtonText.color = Color.black;
         }
    }

    void UpdateProductTextLabel()
    {
        //purchasableProduct[0].productNameText.text = purchasableProduct[0].productName + ": " + purchasableProduct[0].ProductOwnedAmount;
    }

    public void BuyProduct()
    {
         var gold = GetComponentInParent<Gold>();
         if (gold.GoldAmount > purchasableProduct[0].productCost)
         {
             gold.GoldAmount -= purchasableProduct[0].productCost;
             purchasableProduct[0].ProductOwnedAmount += 1;
         }
         else
         {
             Debug.Log("Not enough gold!");
         }
    }

    // IEnumerator ProductGenerateGold()
    // {
    //     while (true)
    //     {
    //         yield return new WaitForSeconds(productProductionTime);
    //         
    //         var gold = GetComponentInParent<Gold>();
    //         int generatedGold = productOwnedAmount * productProductionAmount;
    //         gold.GoldAmount += generatedGold;
    //     }
    // }
}
