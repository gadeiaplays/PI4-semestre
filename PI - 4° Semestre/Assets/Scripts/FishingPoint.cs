using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingPoint : MonoBehaviour
{
    public GameObject icon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            icon.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)

    {
        if (other.gameObject.tag == "Player")
        {
            
            icon.SetActive(false);
        }
    }





}
