//using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gm;
    public int playerInitiativeNumber = 0;
    public bool isRogue = false;
    public bool isMage = false;
    public bool isWarrior = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerInitiative()
    {
        gm.Initiative();

        if (isWarrior) {
            playerInitiativeNumber = gm.initiativeNumber;
            Debug.Log(playerInitiativeNumber);
        }

        if (isRogue) {
            playerInitiativeNumber = gm.initiativeNumber + 5;
            Debug.Log(playerInitiativeNumber);
        }

        if (isMage) {
            playerInitiativeNumber = gm.initiativeNumber - 5;
            Debug.Log(playerInitiativeNumber);
        }

        else {
            playerInitiativeNumber = gm.initiativeNumber;
            Debug.Log(playerInitiativeNumber);
        }
    }
}
