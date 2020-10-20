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

    // Start is called before the first frame update
    void Start()
    {
        goldAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = "Gold: " + goldAmount;
    }

    public void GenerateGold()
    {
        goldAmount += 5;
    }

    private void OnApplicationQuit()
    {
        Save save = CreateSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");

        bf.Serialize(file, save);
        file.Close();

        Debug.Log("Game was saved");
    }
    
    private Save CreateSaveGameObject()
    {
        Save save = new Save();
        int i = 0;

        save.savedGoldAmount = goldAmount;

        return save;
    }
}
