using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBoulder : MonoBehaviour {
    // Start is called before the first frame update
    public float despawnTime = 20f;
    void Start() {
        StartCoroutine(AutoDespawn());
    }

    //collision detector to destroy object 
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Boulder") == false) {
            Destroy(this.gameObject);
        }
    }

    //auto despawner if object doesn't collide with something for some reason
    IEnumerator AutoDespawn() {
        yield return new WaitForSeconds(despawnTime);
        Destroy(this.gameObject);
    }
}
