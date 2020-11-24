using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator anim;
    public Animator anim2;
        
    
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void FadeOut()
    {
        anim.Play("FadeOut");
    }

    public void FadeInDelay()
    {
        anim2.Play("FadeInDelay");
    }

    public void FadeOut2()
    {
        anim2.Play("FadeOut");
    }

   
}
