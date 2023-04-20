using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameManager gm;

    public bool toHit = false;

    public List<int> initiatives = new List<int>();

    //public float initiativeCheck = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies) {
            initiatives.Add(enemy.GetComponent<EnemyController>().enemyInitiativeNumber);
            print(initiatives[1]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToHit() {
        
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
