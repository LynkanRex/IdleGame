using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickArea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rect bounds = new Rect(0, 0, Screen.width / 2, Screen.height);
        if (Input.GetMouseButtonDown(0) && bounds.Contains(Input.mousePosition))
        {
            SendMessage("GenerateGold", SendMessageOptions.DontRequireReceiver);
        }
    }
}
