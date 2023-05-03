using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionScript : MonoBehaviour
{
    public GameManager gm;
    public BattleManager bm;
    public bool selected = false;
    public Color hoverColor;
    public Renderer bodyRend;
    public Color selectedColor;
    public Color defaultColor;
    public EnemyBattleController ebc;


    // Start is called before the first frame update
    void Start()
    {
        defaultColor = bodyRend.material.color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseEnter()
    {
        if (selected == false)
        {
            bodyRend.material.color = hoverColor;
        }
    }

    private void OnMouseExit()
    {
        if (selected == false)
        {
            bodyRend.material.color = defaultColor;
        }
    }

    private void OnMouseDown()
    {
        if (gm.selectedUnit != null)
        {
            // if we're here, something was already selected!
            // 1. Deselect it
            this.gm.selectedUnit.selected = false;
            gm.selectedUnit.bodyRend.material.color = gm.selectedUnit.defaultColor;
        }
        // 2. Select me!
        selected = true;
        bodyRend.material.color = selectedColor;
        print("Is selected");
        gm.SelectUnit(this);
    }
}
