using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Product : MonoBehaviour
{
    [SerializeField] string productName;
    [SerializeField] int productCost = 100;
    [SerializeField] int productProductionTime = 1;
    [SerializeField] int productProductionAmount = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
