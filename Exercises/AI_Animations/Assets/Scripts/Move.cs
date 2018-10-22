
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour {

	public GameObject target;
    NavMeshAgent navMeshAgent;
    public Animator anim;
    public float remainingDistance = 0.1f;


   

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

            if (navMeshAgent.remainingDistance > remainingDistance)
            {
                anim.SetBool("movement", true);
            }
            else
            {
                anim.SetBool("movement", false);
            }
        }
    }
}
