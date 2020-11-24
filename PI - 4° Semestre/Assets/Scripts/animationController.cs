using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class animationController : MonoBehaviour
{
    public GameObject textoRio;

    public Animator anim;
    public Animator anim2;
    public AnimationClip animVara;
    public bool nearWater = false;
    public bool isFishing = false;
    public GameObject gamePrefab;
    public Transform gamePlace;
   

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
            //anim.Play("Armature.001Action");
            // anim.Play("ArmatureAction");
            //StartCoroutine(wait());
            //SceneManager.LoadScene("Fishing");
            GameObject a = Instantiate(gamePrefab) as GameObject;
            a.transform.position = new Vector3(gamePlace.position.x, gamePlace.position.y, gamePlace.position.z);
            a.transform.SetParent(gamePlace.transform);
        }

        //IEnumerator wait()
        {
        //  yield return new WaitForSeconds(animVara.length * anim.speed);
        //  SceneManager.LoadScene("Fishing");
        }


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "fishingArea")
        {

            nearWater = true;

        }

        else if (other.gameObject.tag == "river" && Input.GetKeyDown(KeyCode.E))
        {
            textoRio.SetActive(true);
            anim2.Play("FadeinRio");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "fishingArea")
        {
            nearWater = false;
        }

       
       
    }

    public void ResultadoPesca(bool resultado)
    {
        if (resultado == true)
        {
            Debug.Log("ganhaste");
        }
        else if(resultado == false)
        {
            Debug.Log("perdeste");
        }

        Destroy(GameObject.FindGameObjectWithTag("GamePesca"));
    }

}
