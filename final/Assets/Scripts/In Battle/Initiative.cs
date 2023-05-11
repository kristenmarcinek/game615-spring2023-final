using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initiative : MonoBehaviour
{
    public GameManager gm;
    public int initiativeNumber = 0;
    public bool activeTurn = false;

    // Start is called before the first frame update
    void Start()
    {
        gm.Initiative();

        initiativeNumber = gm.initiativeNumber;
        Debug.Log(initiativeNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
