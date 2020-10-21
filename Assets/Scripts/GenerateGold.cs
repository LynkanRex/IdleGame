
using UnityEngine;

public class GenerateGold : MonoBehaviour
{
    [SerializeField] public int goldGainAmountPerClick = 5;

    public void CreateGold()
    {
        var _gold = GetComponentInParent<Gold>();
        _gold.GoldAmount += goldGainAmountPerClick;
    }
}
