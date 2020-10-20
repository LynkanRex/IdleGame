using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    int _goldAmount;
    public Text goldText;

    public int GoldAmount
    {
        get
        {
            return _goldAmount;
        }
        set
        {
            _goldAmount = value;
            goldText.text = "Gold: " + value;
        }
    }
    
    
    public int goldPressesOwned = 0;
    public Text goldPressText;

    public Text goldPressButtonText;
    
    [SerializeField] int goldGainAmount = 5;
    [SerializeField] int goldPressCost = 100;
    [SerializeField] int goldPressGoldAmount = 1;
    [SerializeField] int goldPressProductionTime = 1;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        GoldAmount = 0;
        goldPressesOwned = 0;
        LoadGame();
        
        StartCoroutine("PressGenerateGold");
    }
    
    // Autosaves our progress when the Game is closed
    private void OnApplicationQuit()
    {
        SaveGame();
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = "Gold: " + GoldAmount;
        goldPressText.text = "Presses: " + goldPressesOwned;

        if (GoldAmount < goldPressCost)
        {
            goldPressButtonText.color = Color.red;
        }
        else
        {
            goldPressButtonText.color = Color.black;
        }
    }

    private void GenerateGold()
    {
        GoldAmount += goldGainAmount;
    }

    IEnumerator PressGenerateGold()
    {
        while (true)
        {
            yield return new WaitForSeconds(goldPressProductionTime);
            
            int generatedGold = goldPressesOwned * goldPressGoldAmount;
            GoldAmount += generatedGold;

            //Debug.Log($"Generated {generatedGold} gold via presses.");
        }
    }
    
    public void BuyGoldPress()
    {

        if (GoldAmount > goldPressCost)
        {
            GoldAmount -= goldPressCost;
            goldPressesOwned += 1;
        }
        else
        {
            Debug.Log("Not enough gold!");
        }
    }
    
    
    
    
    
    
    private Save CreateSaveGameObject()
    {
        Save save = new Save();

        save.savedGoldAmount = GoldAmount;
        save.savedGoldPressesOwned = goldPressesOwned;

        return save;
    }

    private void SaveGame()
    {
        Save save = CreateSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savegame.save");

        bf.Serialize(file, save);
        file.Close();

        Debug.Log($"Game was saved with {GoldAmount} gold");
    }
    
    private void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/savegame.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savegame.save",
                FileMode.Open);
            Save save = (Save) bf.Deserialize(file);
            file.Close();
            
            
            goldText.text = "Gold: " + save.savedGoldAmount;
            GoldAmount = save.savedGoldAmount;

            goldPressText.text = "Presses: " + save.savedGoldPressesOwned;
            goldPressesOwned = save.savedGoldPressesOwned;
            
            Debug.Log($"Game loaded");
            
        }
        else
        {
            Debug.Log("No Savegame found, first time playing?");
        }
    }
}
