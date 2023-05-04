//using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gm;
    public Animator anim;
    public bool isWalking;
    

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
           if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isIdle", false);
            print("you're pressing W");
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", true);
        }
    }

   
}
