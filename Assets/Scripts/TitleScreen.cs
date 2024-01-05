using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    
    public void PlayGame ()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void iceWorld ()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void lavaWorld ()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void graveyardWorld ()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
    



   

   
}
