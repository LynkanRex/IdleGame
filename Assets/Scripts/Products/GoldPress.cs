using UnityEngine;
using UnityEngine.UI;

public class GoldPress : MonoBehaviour {
    public int productionAmount = 1;
    public int costs = 100;
    public float productionTime = 1f;
    public Text goldPressAmountText;
    float elapsedTime;


    private Gold _gold;
    
    public Text BuyPressButtonText;
    
    public int GoldPressAmount {
        get => PlayerPrefs.GetInt("GoldPress", 0);
        set {
            PlayerPrefs.SetInt("GoldPress", value);
            UpdateGoldPressAmountLabel();
        }
    }

    private int totalCost
    {
        get
        {
            return ((costs * GoldPressAmount) / 10) + costs;
        }   
    }

    void UpdateGoldPressAmountLabel() {
        this.goldPressAmountText.text = this.GoldPressAmount.ToString("0 Presses");
    }

    void UpdateGoldPressButtonLabel()
    {
        int totals = (costs * GoldPressAmount) / 10 + costs; 
        this.BuyPressButtonText.text = totals.ToString("Buy Press: 0 Gold");
    }

    void Start() {
        _gold = FindObjectOfType<Gold>();
        UpdateGoldPressAmountLabel();
        UpdateGoldPressButtonLabel();
    }
	
    void Update() {
        this.elapsedTime += Time.deltaTime;
        if (this.elapsedTime >= this.productionTime) {
            ProduceGold();
            this.elapsedTime -= this.productionTime; // DO NOT SET TO ZERO HERE
        }
        
        
        if (_gold.GoldAmount < totalCost)
        {
            this.BuyPressButtonText.color = Color.red;
        }
        else
        {
            this.BuyPressButtonText.color = Color.black;
        }
        
    }

    void ProduceGold() {
        _gold.GoldAmount += this.productionAmount * this.GoldPressAmount;
    }

    public void BuyGoldPress() {

        int costIncrease = (costs * GoldPressAmount) / 10;
        if (_gold.GoldAmount >= totalCost) {
            _gold.GoldAmount -= this.totalCost;
            this.GoldPressAmount += 1;
        }

        UpdateGoldPressButtonLabel();
    }
}