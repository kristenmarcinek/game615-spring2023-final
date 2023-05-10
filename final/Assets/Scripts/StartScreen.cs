using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartScreen : MonoBehaviour
{

    public GameObject IntroTextPanel;
    public bool introShown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        introShown = true;
        IntroTextPanel.SetActive(true);
        if(introShown) 
        {
            StartCoroutine(IntroShown());
        }
    }

    IEnumerator IntroShown()
    {
        yield return new WaitForSeconds(15f);
        IntroTextPanel.SetActive(false);
        introShown = false;
        Destroy(IntroTextPanel);
        //Destroy(this.gameObject);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(sceneName:"BattleScene");
    }
}
