//using System.Diagnostics;
//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int initiativeNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initiative()
    {
        initiativeNumber = Random.Range(1, 20);
        Debug.Log(initiativeNumber);
    }
}
