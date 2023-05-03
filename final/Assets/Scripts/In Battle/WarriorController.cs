using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorController : MonoBehaviour
{
    public GameManager gm;
    // public int playerInitiativeNumber = 0;
    public int warriorHealth = 40;
    public BattleManager bm;
    public int warriorDamage = 0;
    public int warriorHitMod = 30;

    // Start is called before the first frame update
    void Start()
    {
        // gm.Initiative();

        // playerInitiativeNumber = gm.initiativeNumber;
        // Debug.Log(playerInitiativeNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WarriorAttack() {
        bm.turnPlayerHitMod = warriorHitMod;
        bm.ToHit();

        if(bm.attackHits == true)
        {
            warriorDamage = Random.Range(1,8);
            warriorDamage = warriorDamage + 3;
            Debug.Log(warriorDamage);
            this.gm.selectedUnit.ebc.skellyHP = this.gm.selectedUnit.ebc.skellyHP - warriorDamage;
            print(this.gm.selectedUnit.ebc.skellyHP);

            bm.attackHits = false;
            warriorDamage = 0;
        }
        else
        {
            //player missed
            warriorDamage = 0;
            Debug.Log("Miss!");
        }
    }

    public void WarriorHeavyAttack() {
        bm.turnPlayerHitMod = warriorHitMod - 20;
        bm.ToHit();

        if(bm.attackHits == true)
        {
            warriorDamage = Random.Range(1,12);
            warriorDamage = warriorDamage + 5;
            Debug.Log(warriorDamage);
            this.gm.selectedUnit.ebc.skellyHP = this.gm.selectedUnit.ebc.skellyHP - warriorDamage;
            print(this.gm.selectedUnit.ebc.skellyHP);

            bm.attackHits = false;
            warriorDamage = 0;
            warriorHitMod = 30;
        }
        else
        {
            //player missed
            warriorDamage = 0;
            Debug.Log("Miss!");
        }
    }
}
