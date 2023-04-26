using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorController : MonoBehaviour
{
    public GameManager gm;
    public int playerInitiativeNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        gm.Initiative();

        playerInitiativeNumber = gm.initiativeNumber;
        Debug.Log(playerInitiativeNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WarriorAttack() {

    }

    public void WarriorHeavyAttack() {

    }
}
