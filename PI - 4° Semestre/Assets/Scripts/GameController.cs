using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameController : MonoBehaviour
{
    public Text fishes;
        
    public static GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        if (gc == null)
        {
            gc = this;
        }

    }

    // Update is called once per frame
    void Update()
    {
        fishes.text = "Peixes: " + (GameObject.Find("FishingMiniGame").GetComponent<FishingMiniGame>().fishCought);
    }


 
}
