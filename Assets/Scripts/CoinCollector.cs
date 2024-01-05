using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CoinCollector : MonoBehaviour
{
    
    private TextMeshProUGUI scoreText;
    private GameObject coinTextObject;
    private GameObject musicObject;


    //when level loads we want score to show the current value
    private void Start() {
        coinTextObject = GameObject.FindGameObjectWithTag("CoinDisplay");
        scoreText = coinTextObject.GetComponent<TextMeshProUGUI>();
        musicObject = GameObject.FindGameObjectWithTag("SoundManager");
        updateScoreDisplay();
        //coinPickupSound = Music.Load<AudioClip>("Coin_1");
    }

    //update value when coin is collected
    private void OnTriggerEnter2D(Collider2D other){
    	if (other.transform.tag == "coin") {
            PlayerStats.gameScore += 1;
            updateScoreDisplay();
            musicObject.GetComponent<SoundManager>().playCoinSound();
            Destroy(other.gameObject);
        }
    }

    public void updateScoreDisplay() {
        scoreText.text = "Score: " + PlayerStats.gameScore.ToString();
    }
}
