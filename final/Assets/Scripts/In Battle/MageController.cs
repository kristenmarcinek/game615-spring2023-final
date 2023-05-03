using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MageController : MonoBehaviour
{
    public GameManager gm;
    // public int playerInitiativeNumber = 0;
    public int mageHitMod = 40;
    public BattleManager bm;
    public int mageDamage = 0;
    public int mageHP = 20;
    public TMP_Text incomingDamageBox;
   // public int incomingDamage;

    // Start is called before the first frame update
    void Start()
    {
        // gm.Initiative();

        // playerInitiativeNumber = gm.initiativeNumber - 5;
        // Debug.Log(playerInitiativeNumber);

        //incomingDamageBox = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MageAttack() {
        print("Button clicked!");

        bm.turnPlayerHitMod = mageHitMod;
        bm.ToHit();
        if(bm.attackHits == true)
        {
            mageDamage = Random.Range(1,4);
            mageDamage = mageDamage + 1;
            Debug.Log(mageDamage);
            this.gm.selectedUnit.ebc.skellyHP = this.gm.selectedUnit.ebc.skellyHP - mageDamage;
            print(this.gm.selectedUnit.ebc.skellyHP);

            bm.attackHits = false;
            mageDamage = 0;
        }
        else
        {
            //player missed
            mageDamage = 0;
            Debug.Log("Miss!");
        }
    }

    public void MageRangedAttack() {
        bm.turnPlayerHitMod = mageHitMod;
        bm.ToHit();
        if(bm.attackHits == true)
        {
            mageDamage = Random.Range(1,12);
            mageDamage = mageDamage + 5;
            Debug.Log(mageDamage);
            this.gm.selectedUnit.ebc.skellyHP = this.gm.selectedUnit.ebc.skellyHP - mageDamage;
            print(this.gm.selectedUnit.ebc.skellyHP);

            bm.attackHits = false;
            mageDamage = 0;
        }
        else
        {
            //player missed
            mageDamage = 0;
            Debug.Log("Miss!");
        }

    }
   // private void OnCollisionEnter(Collider other)
    //{
      //  if (other.CompareTag("projectile"))
      //  {
       //     incomingDamageBox.enabled = !incomingDamageBox.enabled;


      //  }

      //  if (other.CompareTag("Enemy"))
     //   {
      //      incomingDamageBox.enabled = !incomingDamageBox.enabled;
     //   }


  //  }
}

