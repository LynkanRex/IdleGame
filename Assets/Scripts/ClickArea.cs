using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ClickArea : MonoBehaviour
{

    private Rect bounds;

    // Start is called before the first frame update
    void Start()
    {
        bounds = new Rect(0, 0, Screen.width / 2, Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && bounds.Contains(Input.mousePosition))
        {
            AreaClicked();
        }
    }

    private void AreaClicked()
    {
        var gold = GetComponentInParent<GenerateGold>();
        gold.CreateGold();
    }
}
