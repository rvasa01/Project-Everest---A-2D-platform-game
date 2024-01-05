using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject followObject;
    public Vector2 followOffset;
    private Vector2 threshold;
    public float defaultSpeed;
    private Rigidbody2D rb;

    float cameraZ;


    // Start is called before the first frame update
    void Start() {
        cameraZ = transform.position.z;
        threshold = calculateThreshold();
        rb = followObject.GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void FixedUpdate() {
        //get distance of character from center of camera
        Vector2 follow = followObject.transform.position;
        float xDifference = Vector2.Distance(Vector2.right * transform.position.x , Vector2.right * follow.x );
        float yDifference = Vector2.Distance(Vector2.up * transform.position.y , Vector2.up * follow.y );

        //if character has moved far enough away from the camera center, update the camera position
        Vector3 newPosition = transform.position;
        if(Mathf.Abs(xDifference) >= threshold.x) {
            newPosition.x = follow.x;
        }
        if(Mathf.Abs(yDifference) >= threshold.y) {
            newPosition.y = follow.y;
        }

        //move camera towards new player position (at the minimum speed or faster)
        float moveSpeed = rb.velocity.magnitude;
        if(moveSpeed < defaultSpeed) {
            moveSpeed = defaultSpeed;
        }
        transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
    }


    //get the threshold, using aspect ratio of user screen
    private Vector3 calculateThreshold() {
        Rect aspect = Camera.main.pixelRect;
        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height , Camera.main.orthographicSize);
        t.x -= followOffset.x;
        t.y -= followOffset.y;
        return t;
    }

    public void cameraToPlayer() {
        //only change x and y, changing Z will cause the Camera to zoom in
        Vector3 newCameraPos = followObject.transform.position;
        transform.position = new Vector3(newCameraPos.x, newCameraPos.y, cameraZ);
    }


    //gizmo to help us visualize threshold box
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Vector2 border = calculateThreshold();
        Gizmos.DrawWireCube( transform.position, new Vector3(border.x*2, border.y*2, 1) );
    }    
}





