using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public bool Exists => this.value != null;

    public GameObject value;

    // Update is called once per frame
    void Update()
    {
        if (!this.Exists)
        {
            Destroy(this);
        }
    }
}
