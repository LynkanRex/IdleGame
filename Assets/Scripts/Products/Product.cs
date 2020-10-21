using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Product : MonoBehaviour
{

    public PurchasableProduct[] purchasableProducts;
    public Transform purchasableProductParent;
    public GameObject purchasableProductPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var purchasableProduct in this.purchasableProducts)
        {
            var instance = Instantiate(this.purchasableProductPrefab, this.purchasableProductParent);
            instance.GetComponent<PurchasableProductionUnitScript>().SetUp(purchasableProduct);
        }
    }
}
