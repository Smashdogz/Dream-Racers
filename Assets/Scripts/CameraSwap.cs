using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
public GameObject camera1;
public GameObject camera2;

    // Update is called once per frame
    void Update()
    {
        //1st person camera
       if(Input.GetButtonDown("1stPerson")){
           camera1.SetActive(true);
          camera2.SetActive(false);

        }
        //3rd person camera
       if(Input.GetButtonDown("3rdPerson")){
           camera2.SetActive(true);
           camera1.SetActive(false);

      }
        
   }

}
