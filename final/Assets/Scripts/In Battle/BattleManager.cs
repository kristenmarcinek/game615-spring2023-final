using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BattleManager : MonoBehaviour
{
    public GameManager gm;
    //Initiative inOrder;

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
    // string characterBools = "First";
    public GameObject MageUI;
    public GameObject RogueUI;
    public GameObject WarriorUI;
    GameObject x;

    public float initiativeCheck;
    public bool checkIsRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        initiativeCheck = 15;

        MageUI = GameObject.Find("MageUI");
        RogueUI = GameObject.Find("RogueUI");
        WarriorUI = GameObject.Find("WarriorUI");

        MageUI.SetActive(false);
        WarriorUI.SetActive(false);
        RogueUI.SetActive(false);

        hitBase = 50;
        turnPlayerHitMod = 40;
        //selectedEnemyDodge = 20;
        attackHits = false;

        GameObject[] characters = GameObject.FindGameObjectsWithTag("Character");
        for (int i = 0; i < characters.Length; i++)
        {
            //Initiative inOrder = characters[i].GetComponent<Initiative>();
            x = characters[i];
            initiatives = characters.OrderByDescending(x => x.GetComponent<Initiative>().initiativeNumber).ToList();
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

        initiatives[0].GetComponent<Initiative>().activeTurn = true;
        initiatives[1].GetComponent<Initiative>().activeTurn = false;
        initiatives[2].GetComponent<Initiative>().activeTurn = false;
        initiatives[3].GetComponent<Initiative>().activeTurn = false;
        print(initiatives[0].gameObject.name + " the name");
        print(initiatives[0].GetComponent<Initiative>().activeTurn + "first turn active?");

        // switch (characterBools)
        // {
        //     case "First":
        //         initiatives[0].GetComponent<Initiative>().activeTurn = true;
        //         print("wooooo " + initiatives[0].GetComponent<Initiative>().GetComponent<Initiative>().activeTurn);
        //         initiatives[1].GetComponent<Initiative>().activeTurn = false;
        //         initiatives[2].GetComponent<Initiative>().activeTurn = false;
        //         initiatives[3].GetComponent<Initiative>().activeTurn = false;
        //         break;
        //     case "Second":
        //         initiatives[0].GetComponent<Initiative>().activeTurn = false;
        //         initiatives[1].GetComponent<Initiative>().activeTurn = true;
        //         initiatives[2].GetComponent<Initiative>().activeTurn = false;
        //         initiatives[3].GetComponent<Initiative>().activeTurn = false;
        //         break;
        //     case "Third":
        //         initiatives[0].GetComponent<Initiative>().activeTurn = false;
        //         initiatives[1].GetComponent<Initiative>().activeTurn = false;
        //         initiatives[2].GetComponent<Initiative>().activeTurn = true;
        //         initiatives[3].GetComponent<Initiative>().activeTurn = false;
        //         break;
        //     case "Fourth":
        //         initiatives[0].GetComponent<Initiative>().activeTurn = false;
        //         initiatives[1].GetComponent<Initiative>().activeTurn = false;
        //         initiatives[2].GetComponent<Initiative>().activeTurn = false;
        //         initiatives[3].GetComponent<Initiative>().activeTurn = true;
        //         break;
        // }
    }

    // Update is called once per frame
    void Update()
    {
        // StartCoroutine(TurnOrder());

        if (initiatives[0].GetComponent<Initiative>().activeTurn)
        {
            print("This coroutine worked?");
            checkIsRunning = true;
            StartTimer();
            print(initiativeCheck + "why is it 0");

            StartCoroutine(FirstTurn());

            if (initiativeCheck <= 0)
            {
                print("Checking coroutines");
                StopCoroutine(FirstTurn());
                checkIsRunning = false;
                initiativeCheck = 15;
                initiatives[0].GetComponent<Initiative>().activeTurn = false;
                initiatives[1].GetComponent<Initiative>().activeTurn = true;
                print("first turn is " + initiatives[0].GetComponent<Initiative>().activeTurn);
                print("second turn is " + initiatives[1].GetComponent<Initiative>().activeTurn);
                // characterBools = "Second";
            }
        }

        else if (initiatives[1].GetComponent<Initiative>().activeTurn)
        {
            print("Second coroutine");
            checkIsRunning = true;
            StartTimer();

            StartCoroutine(SecondTurn());

            if (initiativeCheck <= 0)
            {
                StopCoroutine(SecondTurn());
                checkIsRunning = false;
                initiativeCheck = 15;
                initiatives[1].GetComponent<Initiative>().activeTurn = false;
                initiatives[2].GetComponent<Initiative>().activeTurn = true;
                // characterBools = "Third";
            }
        }

        else if (initiatives[2].GetComponent<Initiative>().activeTurn)
        {
            print("Third coroutine");
            checkIsRunning = true;
            StartTimer();

            StartCoroutine(SecondTurn());

            if (initiativeCheck <= 0)
            {
                StopCoroutine(ThirdTurn());
                checkIsRunning = false;
                initiativeCheck = 15;
                initiatives[2].GetComponent<Initiative>().activeTurn = false;
                initiatives[3].GetComponent<Initiative>().activeTurn = true;
                // characterBools = "Third";
            }
        }
    }

    public void ToHit()
    {
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

    // IEnumerator TurnOrder() {
    //     if(characterBools.Contains("First")) {
    //         if(initiatives[0].gameObject.name == "MageControllerObject") {
    //             MageUI.SetActive(true);
    //             WarriorUI.SetActive(false);
    //             RogueUI.SetActive(false);
    //         }

    //         if(initiatives[0].gameObject.name == "WarriorControllerObject") {
    //             MageUI.SetActive(false);
    //             WarriorUI.SetActive(true);
    //             RogueUI.SetActive(false);
    //         }

    //         if(initiatives[0].gameObject.name == "RogueControllerObject") {
    //             MageUI.SetActive(false);
    //             WarriorUI.SetActive(false);
    //             RogueUI.SetActive(true);
    //         }
    //         initiatives[0].GetComponent<Initiative>().activeTurn = false;
    //         characterBools = "Second";
    //     }

    //     else if(characterBools.Contains("Second")) {
    //         if(initiatives[1].gameObject.name == "MageControllerObject") {
    //             MageUI.SetActive(true);
    //             WarriorUI.SetActive(false);
    //             RogueUI.SetActive(false);
    //         }

    //         if(initiatives[1].gameObject.name == "WarriorControllerObject") {
    //             MageUI.SetActive(false);
    //             WarriorUI.SetActive(true);
    //             RogueUI.SetActive(false);
    //         }

    //         if(initiatives[1].gameObject.name == "RogueControllerObject") {
    //             MageUI.SetActive(false);
    //             WarriorUI.SetActive(false);
    //             RogueUI.SetActive(true);
    //         }

    //         initiatives[1].GetComponent<Initiative>().activeTurn = false;
    //         characterBools = "Third";
    //     }

    //     else if(characterBools.Contains("Third")) {
    //         if(initiatives[2].gameObject.name == "MageControllerObject") {
    //             MageUI.SetActive(true);
    //             WarriorUI.SetActive(false);
    //             RogueUI.SetActive(false);
    //         }

    //         if(initiatives[2].gameObject.name == "WarriorControllerObject") {
    //             MageUI.SetActive(false);
    //             WarriorUI.SetActive(true);
    //             RogueUI.SetActive(false);
    //         }

    //         if(initiatives[2].gameObject.name == "RogueControllerObject") {
    //             MageUI.SetActive(false);
    //             WarriorUI.SetActive(false);
    //             RogueUI.SetActive(true);
    //         }

    //         initiatives[2].GetComponent<Initiative>().activeTurn = false;
    //         characterBools = "Fourth";
    //     }

    //     else if(characterBools.Contains("Fourth")) {
    //         if(initiatives[3].gameObject.name == "MageControllerObject") {
    //             MageUI.SetActive(true);
    //             WarriorUI.SetActive(false);
    //             RogueUI.SetActive(false);
    //         }

    //         if(initiatives[3].gameObject.name == "WarriorControllerObject") {
    //             MageUI.SetActive(false);
    //             WarriorUI.SetActive(true);
    //             RogueUI.SetActive(false);
    //         }

    //         if(initiatives[3].gameObject.name == "RogueControllerObject") {
    //             MageUI.SetActive(false);
    //             WarriorUI.SetActive(false);
    //             RogueUI.SetActive(true);
    //         }

    //         initiatives[3].GetComponent<Initiative>().activeTurn = false;
    //         characterBools = "First";
    //     }

    //     else {
    //        StopCoroutine(TurnOrder());
    //     }

    //     yield return new WaitForSeconds(15.0f);
    // }

    IEnumerator FirstTurn()
    {
        if (initiatives[0].gameObject.name == "MageControllerObject")
        {
            MageUI.SetActive(true);
            WarriorUI.SetActive(false);
            RogueUI.SetActive(false);
        }

        if (initiatives[0].gameObject.name == "WarriorControllerObject")
        {
            MageUI.SetActive(false);
            WarriorUI.SetActive(true);
            RogueUI.SetActive(false);
        }

        if (initiatives[0].gameObject.name == "RogueControllerObject")
        {
            MageUI.SetActive(false);
            WarriorUI.SetActive(false);
            RogueUI.SetActive(true);
        }

        yield return null;
    }

    IEnumerator SecondTurn()
    {
        if (initiatives[1].gameObject.name == "MageControllerObject")
        {
            MageUI.SetActive(true);
            WarriorUI.SetActive(false);
            RogueUI.SetActive(false);
        }

        if (initiatives[1].gameObject.name == "WarriorControllerObject")
        {
            MageUI.SetActive(false);
            WarriorUI.SetActive(true);
            RogueUI.SetActive(false);
        }

        if (initiatives[1].gameObject.name == "RogueControllerObject")
        {
            MageUI.SetActive(false);
            WarriorUI.SetActive(false);
            RogueUI.SetActive(true);
        }
        yield return null;
    }

    IEnumerator ThirdTurn()
    {
        if (initiatives[2].gameObject.name == "MageControllerObject")
        {
            MageUI.SetActive(true);
            WarriorUI.SetActive(false);
            RogueUI.SetActive(false);
        }

        if (initiatives[2].gameObject.name == "WarriorControllerObject")
        {
            MageUI.SetActive(false);
            WarriorUI.SetActive(true);
            RogueUI.SetActive(false);
        }

        if (initiatives[2].gameObject.name == "RogueControllerObject")
        {
            MageUI.SetActive(false);
            WarriorUI.SetActive(false);
            RogueUI.SetActive(true);
        }
        yield return null;
    }

    public void StartTimer()
    {
        if (checkIsRunning)
        {
            if (initiativeCheck > 0)
            {
                initiativeCheck -= Time.deltaTime;
                print(initiativeCheck + " timer");
            }
        }
    }
}
