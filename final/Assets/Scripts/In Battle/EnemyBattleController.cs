using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleController : MonoBehaviour
{
    public GameManager gm;
    public BattleManager bm;
    public MageController mc;
    public RogueController rc;
    public WarriorController wc;
    //public bool inBattle = false;
    //public int enemyInitiativeNumber = 0;
    public int enemyDodge = 20;
    public int skellyHP = 60;
    public int skellyHitMod = 30;
    public int skellyDamage;

    // Start is called before the first frame update
    void Start()
    {
        // gm.Initiative();
        // enemyInitiativeNumber = gm.initiativeNumber;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnemiesAttack()
    {
        bm.turnPlayerHitMod = skellyHitMod;
        Random.Range(1, 3);
        bm.ToHit();
        if (bm.attackHits == true)
        {
            skellyDamage = Random.Range(1, 6);
            skellyDamage = skellyDamage + 3;
            Debug.Log(skellyDamage);
            int playerNum = Random.Range(1, 4);
            if (playerNum == 1)
            {
                mc.mageHP = mc.mageHP - skellyDamage;
                print(mc.mageHP);
            }

            if (playerNum == 2)
            {
                rc.rogueHP = rc.rogueHP - skellyDamage;
                print(rc.rogueHP);
            }
            if (playerNum == 3)
            {
                wc.warriorHP = wc.warriorHP - skellyDamage;
                print(wc.warriorHP);
            }
            bm.attackHits = false;
            skellyDamage = 0;
        }
        else
        {
            //player missed
            skellyDamage = 0;
            Debug.Log("Miss!");
        }
    }
}
