using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour {

    public string nextScene;
    

    private void OnTriggerEnter2D(Collider2D other){
        if (other.transform.tag == "Player") {
            Debug.Log("Changing to scene "+nextScene);
            SceneManager.LoadScene(nextScene);            
        }
    }
}
