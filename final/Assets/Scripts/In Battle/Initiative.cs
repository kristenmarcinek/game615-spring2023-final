using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initiative : MonoBehaviour
{
    public GameManager gm;
    //public int playerInitiativeNumber = 0;
    //public int enemyInitiativeNumber = 0;
    public int initiativeNumber;

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.tag == "Player") {
            PlayerInitiative();
        }

        if (this.gameObject.tag == "Enemy") {
            EnemyInitiative();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerInitiative()
    {
        gm.Initiative();

        initiativeNumber = gm.initiativeNumber;
        Debug.Log(initiativeNumber);
    }

    public void EnemyInitiative() 
    {
        gm.Initiative();

        initiativeNumber = gm.initiativeNumber;
        Debug.Log(initiativeNumber);
    }
}
