using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed = 2f;
    private int waypointIndex = 0;          //index of current waypoint we are following


    // Update is called once per frame
    void Update() {
        Vector3 waypointPos = waypoints[waypointIndex].transform.position;
        Vector3 objectPos = transform.position;

        //update waypoint and make sure we dont overshoot
        if( Vector2.Distance(waypointPos, objectPos) < .1f ) {
            waypointIndex ++;
            if(waypointIndex >= waypoints.Length) waypointIndex = 0;
        }
        //reload waypointPos
        waypointPos = waypoints[waypointIndex].transform.position;
        //moves the platform from current position towards the waypoint, with the specified speed given frame rate
        transform.position = Vector2.MoveTowards( objectPos, waypointPos, (Time.deltaTime * speed) );
    }
}
