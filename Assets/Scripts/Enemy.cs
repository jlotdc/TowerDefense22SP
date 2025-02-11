using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    // ====SETTINGS AND VARIABLES =====

    [SerializeField] float speed = 5f;

    [SerializeField] EventManagerSO eventManager;

    [SerializeField] int reward = 20;

    [SerializeField] float maxHealth = 100;
    [SerializeField] float currentHealth;
    [SerializeField] HealthBar HealthBar;




    //Pathfinding related
    [SerializeField] EnemyPath path; //The 'map' or path
    [SerializeField] int currentTragetWaypointIndex = 0; //Which point to target on the list
    bool destinationReached = false;
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    // Start is called before the first frame update
    void Start()
    {
       currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {


        if (!destinationReached && path != null)
        {

            if(agent.hasPath && !agent.pathPending)
            {
                //are we close enough to destination
                if (agent.remainingDistance < 1f)
                {
                    currentTragetWaypointIndex++;

                    if (currentTragetWaypointIndex >= path.GetTotalNumberofWaypoints())
                    {
                        destinationReached = true;
                        return;
                    }

                    agent.SetDestination(path.GetWaypoint(currentTragetWaypointIndex) .position);

                }
            }

            //ctrl k, ctrl k to comment
            //ctrl k, ctrl u to uncomment
        //    transform.position = Vector3.MoveTowards(

        //        transform.position, //current position? 
        //        path.GetWaypoint(currentTragetWaypointIndex).position, // where to?
        //        speed * Time.deltaTime //how fast?
        //        );

        //    // ===Are we close enough to the target waypoint? ===

        //    if (Vector3.Distance(transform.position,
        //        path.GetWaypoint(currentTragetWaypointIndex).position) < 0.1f)
        //    {
        //        //currentTragetWaypointIndex = currentTragetWaypointIndex + 1;
        //        //currentTragetWaypointIndex += 1; 
        //        currentTragetWaypointIndex++;

        //        //Are we at the end?
        //        if (currentTragetWaypointIndex >= path.GetTotalNumberofWaypoints())

        //        {
        //            destinationReached = true;
        //        }

        //    }

        }
    }

    public void SetPath(EnemyPath pathToFollow)
    {
    path = pathToFollow;


        agent.SetDestination(path.GetWaypoint(currentTragetWaypointIndex).position);
        agent.speed = speed;


    }


    public void InflictDamage(float incomingDamage)
    {
        currentHealth -= incomingDamage;

        HealthBar.UpdateHealthBar(currentHealth, maxHealth);


        if (currentHealth <= 0)
        {

            eventManager.MakeMoney(reward);

            Destroy(this.gameObject);
        }

    }



}
