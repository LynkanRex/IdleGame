using UnityEngine;
using UnityEngine.UI;


public class Gold : MonoBehaviour
{
    int _goldAmount;
    private Hud _hud;

    public int GoldAmount
    {
        get => _goldAmount;
        set
        {
            _goldAmount = value;
            _hud.UpdateGoldTextLabel();
        }
    }

    private readonly SaveLoad _saveLoad;

    public Gold()
    {
        _saveLoad = new SaveLoad(this);
    }

    void Awake()
    {
        _hud = GetComponent<Hud>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GoldAmount = 0;
        _saveLoad.LoadGame();
        
    }
    
     //Autosaves our progress when the Game is closed
     private void OnApplicationQuit()
     {
         _saveLoad.SaveGame();
     }
}
