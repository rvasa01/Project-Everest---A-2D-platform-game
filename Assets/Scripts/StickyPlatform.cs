using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    //when Player lands on platform stick to it
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player");
        collision.gameObject.transform.SetParent(transform);
    }

    //when Player leaves on platform stop sticking to it
    private void OnCollisionExit2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player");
        collision.gameObject.transform.SetParent(null);
    }
}
