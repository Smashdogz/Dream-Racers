using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CheckpointManager.laps == 3)
        {
            print("yay");
            SceneManager.LoadScene("VictoryScreen");
        }
    }
}
