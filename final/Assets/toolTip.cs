using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toolTip : MonoBehaviour
{
   public string message;
    private void OnMouseEnter() 
    {
    toolTipManager._instance.SetAndShowToolTip(message);
   }
  private void OnMouseExit() {
    toolTipManager._instance.HideToolTip();
   }
}

