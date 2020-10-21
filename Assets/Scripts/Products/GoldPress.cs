using UnityEngine;
using UnityEngine.UI;

public class GoldPress : MonoBehaviour {
    public int productionAmount = 1;
    public int costs = 100;
    public float productionTime = 1f;
    public Text goldPressAmountText;
    float elapsedTime;


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
        UpdateGoldPressAmountLabel();
        UpdateGoldPressButtonLabel();
    }
	
    void Update() {
        this.elapsedTime += Time.deltaTime;
        if (this.elapsedTime >= this.productionTime) {
            ProduceGold();
            this.elapsedTime -= this.productionTime; // DO NOT SET TO ZERO HERE
        }
        
        var gold = FindObjectOfType<Gold>();
        if (gold.GoldAmount < totalCost)
        {
            this.BuyPressButtonText.color = Color.red;
        }
        else
        {
            this.BuyPressButtonText.color = Color.black;
        }
        
    }
    // something costs 100ct, and I get 40ct per day:
    // IN CASE WE SET IT TO ZERO:
    // 40ct 80ct [120ct (Buy for 100ct) 0ct] 40ct 80ct // In 5 Days, I can buy something for 100ct once, and I have 80ct
    // IN CASE WE DECREASE IT BY THE COSTS:
    // 40ct 80ct [120ct (Buy for 100ct) 20ct] 60ct [100ct (Buy for 100ct) 0ct] // In 5 Days, I can buy something for 100ct twice

    void ProduceGold() {
        var gold = FindObjectOfType<Gold>();
        gold.GoldAmount += this.productionAmount * this.GoldPressAmount;
    }

    public void BuyGoldPress() {
        var gold = FindObjectOfType<Gold>();

        int costIncrease = (costs * GoldPressAmount) / 10;
        if (gold.GoldAmount >= totalCost) {
            gold.GoldAmount -= this.totalCost;
            this.GoldPressAmount += 1;
        }

        UpdateGoldPressButtonLabel();
    }
}