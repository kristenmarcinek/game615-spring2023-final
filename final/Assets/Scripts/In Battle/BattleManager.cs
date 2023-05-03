using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BattleManager : MonoBehaviour
{
    public GameManager gm;
    Initiative inOrder;

    public bool toHit = false;

    //public List<int> initiatives = new List<int>();
    public List<GameObject> initiatives = new List<GameObject>();

    public int hitBase;
    public int turnPlayerHitMod;
    public int selectedEnemyDodge;
    public int hitChance;
    public int hitRoll;
    public bool attackHits;
    public MageController mc;
    public WarriorController wc;
    public RogueController rc;
    public float turnTimer;
    string characterBools = "First";

    //public float initiativeCheck = 0;

    // Start is called before the first frame update
    void Start()
    {
        hitBase = 50;
        turnPlayerHitMod = 40;
        //selectedEnemyDodge = 20;
        attackHits = false;

        GameObject[] characters = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < characters.Length; i++) {
            Initiative inOrder = characters[i].GetComponent<Initiative>();
            initiatives = characters.OrderByDescending(x => inOrder.initiativeNumber).ToList();
        }

        foreach (GameObject i in initiatives)
        {
            Debug.Log("alsdflkasj;df" + i);
        }

        // GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // for (int i = 0; i < enemies.Length; i++) {
        //     EnemyAttack ea = enemies[i].GetComponent<EnemyAttack>();
        //     if (ea != null) {
        //         initiatives.Add(ea.enemyInitiativeNumber);
        //     }         
        // }

        // foreach (int i in initiatives) {
        //     Debug.Log("alsdflkasj;df" + i);
        // }

        // static int SortByInitiative(Initiative p1, Initiative p2) {
        //     return p1.initiativeNumber.CompareTo(p2.initiativeNumber);
        // }

        // initiatives.Sort(SortByInitiative);
        

        switch(characterBools) {
            case "First":
                initiatives[0].active = true;
                initiatives[1].active = false;
                initiatives[2].active = false;
                initiatives[3].active = false;
                break;
            case "Second":
                initiatives[0].active = false;
                initiatives[1].active = true;
                initiatives[2].active = false;
                initiatives[3].active = false;
                break;
            case "Third":
                initiatives[0].active = false;
                initiatives[1].active = false;
                initiatives[2].active = true;
                initiatives[3].active = false;
                break;
            case "Fourth":
                initiatives[0].active = false;
                initiatives[1].active = false;
                initiatives[2].active = false;
                initiatives[3].active = true;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToHit() {
        print(this.gm.selectedUnit.ebc.enemyDodge);
        hitChance = hitBase + turnPlayerHitMod - this.gm.selectedUnit.ebc.enemyDodge;
        print(hitChance);
        hitRoll = Random.Range(1, 100);
        if (hitRoll <= hitChance)
            {
                attackHits = true;
            }
        else
            {
                attackHits = false;
            }
        
        Debug.Log(attackHits);
    }

    IEnumerator TurnOrder() {

        if(characterBools.Contains("First")) {
            // stuff here
            characterBools = "Second";
        }
        
        else if(characterBools.Contains("Second")) {
            // stuff here
            characterBools = "Third";
        }

        else if(characterBools.Contains("Third")) {
            // stuff here
            characterBools = "Fourth";
        }

        else if(characterBools.Contains("Fourth")) {
            // stuff here
            characterBools = "First";
        }

        else {
            // ends battle
        }
        yield return new WaitForSeconds(15);
    }
}
