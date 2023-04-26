using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BattleManager : MonoBehaviour
{
    public GameManager gm;
    public Initiative inOrder;

    public bool toHit = false;

    //public List<int> initiatives = new List<int>();
    public List<GameObject> initiatives = new List<GameObject>();

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
}
