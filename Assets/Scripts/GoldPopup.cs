using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldPopup : MonoBehaviour
{

    [SerializeField] public Transform goldGainPopup;

    public float lifeTime;
    private float _livedTime = 0f;
    
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


    private void Update()
    {
        _livedTime += Time.deltaTime;
        
        var moveSpeed = 5f;
        this.transform.Translate(new Vector3(0,moveSpeed * Time.deltaTime,0 ));

        this.textMesh.alpha -= (_livedTime * Time.deltaTime) * 2;
        
        if (_livedTime > lifeTime)
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update

}
