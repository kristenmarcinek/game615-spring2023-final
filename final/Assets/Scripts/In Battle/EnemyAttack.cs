using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameManager gm;
    //public bool inBattle = false;
    public int enemyInitiativeNumber = 0;
    public int enemyDodge = 0;

    // Start is called before the first frame update
    void Start()
    {
        gm.Initiative();
        enemyInitiativeNumber = gm.initiativeNumber;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemiesAttack() {

    }
}
