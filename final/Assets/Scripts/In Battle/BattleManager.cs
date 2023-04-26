using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameManager gm;

    public bool toHit = false;

    public List<int> initiatives = new List<int>();

    public int hitBase;
    public int turnPlayerHitMod;
    public int selectedEnemyDodge;
    public int hitChance;
    public int hitRoll;
    public bool attackHits;

    //public float initiativeCheck = 0;

    // Start is called before the first frame update
    void Start()
    {

        hitBase = 50;
        turnPlayerHitMod = 40;
        selectedEnemyDodge = 20;
        attackHits = false;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies) {
            initiatives.Add(enemy.GetComponent<EnemyController>().enemyInitiativeNumber);
            print(initiatives);            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown ("space"))
        {
            ToHit();
        }
    }

    public void ToHit() {
        hitChance = hitBase + turnPlayerHitMod - selectedEnemyDodge;
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

    public void EnemyAttack() {

    }

    public void RogueAttack() {

    }

    public void RogueSneakAttack() {

    }

    public void WarriorAttack() {

    }

    public void WarriorHeavyAttack() {

    }

    public void MageAttack() {

    }

    public void MageRangedAttack() {

    }
}
