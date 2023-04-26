//using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameManager gm;
    public bool inBattle = false;
    public int enemyInitiativeNumber = 0;
    public int enemyDodge = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        if (inBattle) {
            gm.Initiative();
            enemyInitiativeNumber = gm.initiativeNumber;
        }

        Debug.Log(inBattle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
