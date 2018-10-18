
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour {

	public GameObject target;
    NavMeshAgent navMeshAgent;


   

    // Methods for behaviours to set / add velocities
void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update () 
	{
        if (navMeshAgent && target) {
            navMeshAgent.destination = target.transform.position;

        }
    }
}
