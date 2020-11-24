using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalController: MonoBehaviour
{
    public GameObject menu;
    public bool menuisOn;

    // Start is called before the first frame update
    void Start()
    {
        menuisOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && menuisOn == false)
        {
            menu.SetActive(true);
            menuisOn = true;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && menuisOn == true)
        {
            menu.SetActive(false);
            menuisOn = false;
        }
    }
}
