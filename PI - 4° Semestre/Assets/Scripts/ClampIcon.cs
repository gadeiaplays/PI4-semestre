using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampIcon : MonoBehaviour
{
   // public Text iconLabel;
    public Image iconBox;

      void FixedUpdate()
    {
        Vector3 iconPos = Camera.main.WorldToScreenPoint(this.transform.position);
        //iconLabel.transform.position = iconPos;
        iconBox.transform.position = iconPos;
    }
}
