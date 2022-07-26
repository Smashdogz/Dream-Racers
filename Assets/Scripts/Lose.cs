using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print("Hello");
        print("Enemy laps "+NpcMove.enemyLaps);
        if(NpcMove.enemyLaps == 3)
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }
}
