//using System.Diagnostics;
//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int initiativeNumber = 0;
    public SelectionScript selectedUnit;
    public GameObject cannotRunText;
    public MageController mc;
    public WarriorController wc;
    public RogueController rc;
    public EnemyBattleController ebc;
    public TextMeshProUGUI rogueHPText;
    public TextMeshProUGUI warriorHPText;
    public TextMeshProUGUI mageHPText;
    public TextMeshProUGUI enemyHPText;
    public TextMeshProUGUI necromancerHPText;
    public GameObject IntroTextObj;
    public bool introShown;

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);    
    }

    // Start is called before the first frame update
    void Start()
    {
        introShown = true;
        IntroTextObj.SetActive(true);
        if(introShown) 
        {
            StartCoroutine(IntroShown());
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyHPText.text = "Skeleton " + ebc.skellyHP.ToString() + "/60";
        necromancerHPText.text = "Necromancer " + ebc.skellyHP.ToString() + "/80";
        rogueHPText.text = "Rogue " + rc.rogueHP.ToString() + "/30";
        mageHPText.text = "Mage " + mc.mageHP.ToString() + "/20";
        warriorHPText.text = "Warrior " + wc.warriorHP.ToString() + "/40";

        // if (Input.GetMouseButtonDown(0))
        // {
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     if(Physics.Raycast(ray) == false)
        //     {
        //         if (selectedUnit != null)
        //         {
        //             selectedUnit.selected = false;
        //             selectedUnit.bodyRend.material.color = selectedUnit.defaultColor;

        //             selectedUnit = null;
        //         }
        //     }
        // }
    }

    public void SelectUnit(SelectionScript unit) {
        selectedUnit = unit;

        Vector3 pos = unit.transform.position + Vector3.up * 2.5f;
    }

    public void Initiative()
    {
        initiativeNumber = Random.Range(1, 20);
        Debug.Log(initiativeNumber);
    }

    public void RunAway() 
    {
        int runNum = Random.Range(1, 3);

        if(runNum == 1) {
            StartCoroutine(CannotRun());
        }

        if(runNum == 2) {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            SceneManager.LoadScene(sceneName:"ForestScene");
        }
    }

    IEnumerator CannotRun() {
        cannotRunText.SetActive(true);
        yield return new WaitForSeconds(3f);
        cannotRunText.SetActive(false);
    }

    IEnumerator IntroShown()
    {
        yield return new WaitForSeconds(20f);
        IntroTextObj.SetActive(false);
        introShown = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(sceneName:"ForestScene");
    }

    public void Continue()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(sceneName:"ForestScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
