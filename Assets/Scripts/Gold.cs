using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    public int goldAmount;
    public Text goldText;

    [SerializeField] int goldGainAmount = 5;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        goldAmount = 0;
        LoadGame();
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = "Gold: " + goldAmount;
    }

    public void GenerateGold()
    {
        goldAmount += goldGainAmount;
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private void SaveGame()
    {
        Save save = CreateSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savegame.save");

        bf.Serialize(file, save);
        file.Close();

        Debug.Log($"Game was saved with {goldAmount}");
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
            goldAmount = save.savedGoldAmount;
            
            Debug.Log(Application.persistentDataPath);
            Debug.Log($"Game loaded with {save.savedGoldAmount} gold!");
            
        }
        else
        {
            Debug.Log(Application.persistentDataPath);
            Debug.Log("No Savegame found, first time playing?");
        }
        
    }
    
    private Save CreateSaveGameObject()
    {
        Save save = new Save();
        int i = 0;

        save.savedGoldAmount = goldAmount;

        return save;
    }
}
