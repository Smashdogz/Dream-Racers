using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{

    public Text first;
    public Text second;

void Update()
{
    //Debug.Log((NpcMove.ThisWaypoint)+1);
    //8 checkpoints (player)
    //56 waypoints (enemy)
    if(((NpcMove.ThisWaypoint) +1) > CheckpointManager.checkpoints) {
        if(NpcMove.enemyLaps >= CheckpointManager.laps) {
            print("Losing");
            first.text = "1st: Opponent";
            second.text = "2nd: Player";
        }
    }
    else {
        print("Winning");
        first.text = "1st: Player";
        second.text = "2nd: Opponent";
    }
}

}