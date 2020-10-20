using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoad
{
    private Gold _gold;
    private Product _product;

    public SaveLoad(Gold gold)
    {
        _gold = gold;
    }
    
    

    private Save CreateSaveGameObject()
    {
        Save save = new Save();

        save.savedGoldAmount = _gold.GoldAmount;
        //save.savedGoldPressesOwned = goldPressesOwned;

        return save;
    }

    public void SaveGame()
    {
        Save save = CreateSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savegame.save");

        bf.Serialize(file, save);
        file.Close();

        Debug.Log($"Game was saved with {_gold.GoldAmount} gold");
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/savegame.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savegame.save",
                FileMode.Open);
            Save save = (Save) bf.Deserialize(file);
            file.Close();


            _gold.goldText.text = "Gold: " + save.savedGoldAmount;
            _gold.GoldAmount = save.savedGoldAmount;

            _gold.goldPressText.text = "Presses: " + save.savedGoldPressesOwned;
            //goldPressesOwned = save.savedGoldPressesOwned;
            
            Debug.Log($"Game loaded");
            
        }
        else
        {
            Debug.Log("No Savegame found, first time playing?");
        }
    }
}

