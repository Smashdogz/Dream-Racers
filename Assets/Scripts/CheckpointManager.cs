using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static int checkpoints;
    public static int laps;
    public int checkpointMax = 3;
    public int lapMax = 2;
    public float timeEntered = 0;

    // Start is called before the first frame update
    void Start()
    {
    laps = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(checkpoints == checkpointMax){
            laps = laps +1;
            checkpoints = 1;
            Debug.Log(laps);
            timeEntered = Time.time;
        }

    }

    
}


