using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Encounters : MonoBehaviour
{
    //int encounterNum;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EncounterCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EncounterCountdown()
    {
        yield return new WaitForSeconds(15);

        int encounterNum = Random.Range(1, 3);

        if(encounterNum == 1)
        {
            print(encounterNum);
            StartCoroutine(EncounterCountdown());
        }

        if(encounterNum == 2)
        {
            print(encounterNum);
            SceneManager.LoadScene(sceneName:"BattleScene");
        }
    }
}
