//using System.Diagnostics;
//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int initiativeNumber = 0;
    public SelectionScript selectedUnit;
    public GameObject cannotRunText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
            SceneManager.LoadScene(sceneName:"ForestScene");
        }
    }

    IEnumerator CannotRun() {
        cannotRunText.SetActive(true);
        yield return new WaitForSeconds(3f);
        cannotRunText.SetActive(false);
    }
}
