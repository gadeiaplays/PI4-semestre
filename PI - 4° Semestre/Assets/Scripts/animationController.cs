using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class animationController : MonoBehaviour
{
    public Animator anim;
    public AnimationClip animVara;
    public bool nearWater = false;
    public bool isFishing = false;
   

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && nearWater == true && isFishing == false)
        {
            Pesca();
        }


        void Pesca()
        {
            anim.Play("RodSwing");
            StartCoroutine(wait());

        }

        IEnumerator wait()
        {
            yield return new WaitForSeconds(animVara.length * anim.speed);
            Debug.Log("Começou a pesca!");
            SceneManager.LoadScene("Fishing");
        }


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "fishingArea")
        {

            nearWater = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "fishingArea")
        {
            nearWater = false;
        }
    }

}
