using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    
    private GameObject mainCamera;
    private GameObject musicObject;

    private void Start () {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        musicObject = GameObject.FindGameObjectWithTag("SoundManager");
    }

    private void OnCollisionEnter2D(Collision2D collision)  {
        if (collision.gameObject.CompareTag("Death") || collision.gameObject.CompareTag("Boulder")) {
            Die();
        }
    }

    private void Die() {
        musicObject.GetComponent<SoundManager>().playDeathSound();

        //update player stats & coin display
        PlayerStats.deathCount++;
        PlayerStats.gameScore += PlayerStats.deathScorePenalty;
        gameObject.GetComponent<CoinCollector>().updateScoreDisplay();

        //change player & camera position
        transform.position = PlayerStats.spawnPoint;
        mainCamera.GetComponent<CameraFollow>().cameraToPlayer();
    }
}
