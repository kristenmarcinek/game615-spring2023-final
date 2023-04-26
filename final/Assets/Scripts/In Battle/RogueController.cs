using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueController : MonoBehaviour
{
    public GameManager gm;
    public int playerInitiativeNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        gm.Initiative();

        playerInitiativeNumber = gm.initiativeNumber + 5;
        Debug.Log(playerInitiativeNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RogueAttack() {

    }

    public void RogueSneakAttack() {

    }
}
