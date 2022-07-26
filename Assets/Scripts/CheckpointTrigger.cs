using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    public GameObject checkpointTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){

        if(other.transform.CompareTag("Player")) 
        {
            Debug.Log("checkpoint hit");
            CheckpointManager.checkpoints = CheckpointManager.checkpoints +1;
        }
        


    }
}
