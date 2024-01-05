using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {

    AudioSource audioPlayer;
    public AudioClip coinSound;
    public AudioClip deathSound;

    
    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
        audioPlayer = GetComponent<AudioSource>();
    }

    public void playCoinSound() {
        audioPlayer.PlayOneShot(coinSound);
    }

    public void playDeathSound() {
        audioPlayer.PlayOneShot(deathSound);
    }
}




