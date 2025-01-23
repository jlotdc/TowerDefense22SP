using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{

    [SerializeField] Transform navMeshTarget;
   private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = true;
    }

    private void Start()
    {
        //agent.SetDestination(new Vector3(-2, 0,-21));
       
    }

    private void Update()
    {
        agent.SetDestination(navMeshTarget.position);
    }
}
