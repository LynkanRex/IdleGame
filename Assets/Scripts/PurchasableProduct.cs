using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PurchasableProduct
{
    
    [SerializeField] public string productName = "";
    [SerializeField] int productCost = 100;
    [SerializeField] int productProductionTime = 1;
    [SerializeField] int productProductionAmount = 1;

    [SerializeField] public Text productNameText = null;
    [SerializeField] private Text productButtonText = null;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
