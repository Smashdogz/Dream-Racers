using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NpcMove : MonoBehaviour
{
    public Circuit circuit;
    Vector3 Target;
    public static int ThisWaypoint;
    public Rigidbody sphereFollow;
    public float speed;
    public GameObject enemyModel;
    private bool grounded;
    public Transform groundRayPoint;
    public LayerMask whatIsGround;
    public float groundRayLength = .5f;
    private float turnInput;
    public float turnStrength = 150f;
    public static int enemyLaps;

    // Start is called before the first frame update
    void Start()
    {
        Target = circuit.waypoints[ThisWaypoint].transform.position;
        enemyLaps = 0;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(waiter());
        IEnumerator waiter() {
            yield return new WaitForSeconds(2);
            print(enemyLaps);
            Vector3 tf = sphereFollow.transform.InverseTransformPoint(Target);
            float distanceToTarget = Vector3.Distance(Target,sphereFollow.transform.position);
            enemyModel.transform.LookAt(Target);

            if(grounded)
            {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime * Input.GetAxis("Vertical"), 0f));
            }

            if(distanceToTarget < 5){
                //reduceSpeed
            }
            if(distanceToTarget < 2){
                ThisWaypoint ++;
                if(ThisWaypoint >= circuit.waypoints.Length){
                    ThisWaypoint = 0;
                    enemyLaps++;
                }
                Target = circuit.waypoints[ThisWaypoint].transform.position;
                //reduceSpeed
            }
            
            sphereFollow.transform.position = Vector3.MoveTowards(transform.position, Target, speed * Time.deltaTime);
            transform.position = sphereFollow.transform.position;

            if(Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene("TitleScreen");
            }
        }

    }
    private void FixedUpdate()
    {
       grounded = false;
       RaycastHit hit;

       if(Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLength, whatIsGround))
       {
           grounded = true;

           //transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
       }
    }
}
