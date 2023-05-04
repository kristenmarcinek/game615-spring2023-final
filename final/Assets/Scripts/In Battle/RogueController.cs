using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueController : MonoBehaviour
{
    public GameManager gm;
    // public int playerInitiativeNumber = 0;
    public int rogueHP = 30;
    public int rogueHitMod = 45;
    public BattleManager bm;
    public float rogueDamage = 0;
    public int rogueDamageInt = 0;
    public float[] multipliers = {0, .5f, 2, 3};
    public float damageMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        // gm.Initiative();

        // playerInitiativeNumber = gm.initiativeNumber + 5;
        // Debug.Log(playerInitiativeNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RogueAttack() {
        bm.turnPlayerHitMod = rogueHitMod;
        bm.ToHit();

        if(bm.attackHits == true)
        {
            rogueDamage = Random.Range(1,6);
            rogueDamage = rogueDamage + 3;
            Debug.Log(rogueDamage);
            
            rogueDamageInt = Mathf.FloorToInt(rogueDamage);
            this.gm.selectedUnit.ebc.skellyHP = this.gm.selectedUnit.ebc.skellyHP - rogueDamageInt;
            print(this.gm.selectedUnit.ebc.skellyHP);

            bm.attackHits = false;
            rogueDamage = 0;
        }
        else
        {
            //player missed
            rogueDamage = 0;
            Debug.Log("Miss!");
        }
    }

    public void RogueLuckyStrike() {
        bm.turnPlayerHitMod = rogueHitMod;
        bm.ToHit();

        if(bm.attackHits == true)
        {
            rogueDamage = Random.Range(1,6);
            damageMultiplier = multipliers[Random.Range(0,multipliers.Length)];
            rogueDamage = (rogueDamage + 3) * damageMultiplier;
            Debug.Log(rogueDamage);

            rogueDamageInt = Mathf.FloorToInt(rogueDamage);
            this.gm.selectedUnit.ebc.skellyHP = this.gm.selectedUnit.ebc.skellyHP - rogueDamageInt;
            print(this.gm.selectedUnit.ebc.skellyHP);

            bm.attackHits = false;
            rogueDamage = 0;
        }
        else
        {
            //player missed
            rogueDamage = 0;
            Debug.Log("Miss!");
        }

    }
}
