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
        get => _goldAmount;
        set
        {
            _goldAmount = value;
            UpdateGoldTextLabel();
        }
    }

    public Text goldPressText;

    public Text goldPressButtonText;
    private readonly SaveLoad _saveLoad;

    public Gold()
    {
        _saveLoad = new SaveLoad(this);
    }

    private void UpdateGoldTextLabel()
    {
        goldText.text = "Gold: " + GoldAmount;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        GoldAmount = 0;
        _saveLoad.LoadGame();
    }
    
    // Autosaves our progress when the Game is closed
    private void OnApplicationQuit()
    {
        _saveLoad.SaveGame();
    }
}
