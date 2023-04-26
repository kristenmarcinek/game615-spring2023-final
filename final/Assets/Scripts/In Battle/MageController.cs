using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageController : MonoBehaviour
{
    public GameManager gm;
    public int playerInitiativeNumber = 0;
    public int mageHitMod = 40;
    public BattleManager bm;
    public int mageDamage = 0;
    public int mageHealth = 20;

    // Start is called before the first frame update
    void Start()
    {
        gm.Initiative();

        playerInitiativeNumber = gm.initiativeNumber - 5;
        Debug.Log(playerInitiativeNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MageAttack() {
        bm.turnPlayerHitMod = mageHitMod;
        bm.ToHit();
        if(bm.attackHits == true)
        {
            mageDamage = Random.Range(1,4);
            //SUBTRACT HEALTH
            bm.attackHits = false;
        }
    }

    public void MageRangedAttack() {

    }
}
