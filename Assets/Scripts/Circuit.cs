using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circuit : MonoBehaviour
{
    public GameObject[] waypoints;
    public static int enemyWaypoint;

    void OnDrawGizmos() {
        DrawGizmos(false);
    }

    void OnDrawGizmosSelected() {
        DrawGizmos(true);
    }

    void DrawGizmos(bool selected) {
        //Debug.Log("DrawGizmos");
        if (selected == false) return;
        if (waypoints.Length > 1) {
            Vector3 prev = waypoints[0].transform.position;
            for (int i=1; i < waypoints.Length; i++) {
                Vector3 next = waypoints[i].transform.position;
                Gizmos.DrawLine(prev, next);
                enemyWaypoint++;
                prev = next;
            }
            //Debug.Log(enemyWaypoint);
            Gizmos.DrawLine(prev, waypoints[0].transform.position);
        }
    }

    void Update(){
       // if(){

      //  }
    }
}
