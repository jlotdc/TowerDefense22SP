using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    // ====SETTINGS AND VARIABLES =====

    [SerializeField] float speed = 5f;


    //Pathfinding related
    [SerializeField] EnemyPath path; //The 'map' or path
    [SerializeField] int currentTragetWaypointIndex = 0; //Which point to target on the list
    bool destinationReached = false;



    // Start is called before the first frame update
    void Start()
    {
        // transform.position = new Vector3(0, 5, 0);
    }

    // Update is called once per frame
    void Update()
    {


        if (!destinationReached)
        {

            transform.position = Vector3.MoveTowards(

                transform.position, //current position? 
                path.GetWaypoint(currentTragetWaypointIndex).position, // where to?
                speed * Time.deltaTime //how fast?
                );

            // ===Are we close enough to the target waypoint? ===

            if (Vector3.Distance(transform.position,
                path.GetWaypoint(currentTragetWaypointIndex).position) < 0.1f)
            {
                //currentTragetWaypointIndex = currentTragetWaypointIndex + 1;
                //currentTragetWaypointIndex += 1; 
                currentTragetWaypointIndex++;

                //Are we at the end?
                if (currentTragetWaypointIndex >= path.GetTotalNumberofWaypoints())

                {
                    destinationReached = true;
                }

            }

        }
    }

    public void SetPath(EnemyPath pathToFollow)
    {
    path = pathToFollow;
    }

}
