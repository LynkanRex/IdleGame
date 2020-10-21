using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldPopup : MonoBehaviour
{

    [SerializeField] public Transform goldGainPopup;

    public GoldPopup Create(Vector2 position, int goldAmount)
    {
        Transform goldPopupTransform = Instantiate(goldGainPopup, position, Quaternion.identity);
        GoldPopup goldPopup = goldPopupTransform.GetComponent<GoldPopup>();
        goldPopup.Setup(goldAmount);

        return goldPopup;
    }
    
    
    private TextMeshPro textMesh;
    
    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }
    
    public void Setup(int goldGainAmount)
    {
        textMesh.SetText(goldGainAmount.ToString());
    }
    
    // Start is called before the first frame update

}
