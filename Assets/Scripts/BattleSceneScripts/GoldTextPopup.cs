using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldTextPopup : MonoBehaviour
{

    private float aliveTime;
    

    [SerializeField] private float movementSpeed;
    [SerializeField] private float timer;
    [SerializeField] private float alphaFadeTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
        var text = GetComponent<Text>();
        var color = text.color;
        color.a -= this.alphaFadeTime * Time.deltaTime;
        text.color = color;
        if (color.a <= 0f) {
            Destroy(this.gameObject);
        }
        
    }
}