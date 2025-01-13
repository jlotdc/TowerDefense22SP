using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{

    [SerializeField] List<Transform> waypoints;

    private void Awake()
    {
        //initialize the list 
        waypoints = new List<Transform>();

        //Iterate through all the transforms in the children 
        foreach (Transform waypoint in transform)
        {
            //Add any found waypoints to our list 
            waypoints.Add(waypoint);
        }

    }

    public Transform GetWaypoint(int indexOfWaypoint)
    {
        return waypoints[indexOfWaypoint];
    }

    public int GetTotalNumberofWaypoints (
        )
    {
        return waypoints.Count;
    }
}
