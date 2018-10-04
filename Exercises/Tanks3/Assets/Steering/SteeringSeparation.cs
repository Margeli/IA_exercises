using UnityEngine;
using System.Collections;

public class SteeringSeparation : MonoBehaviour {

	public LayerMask mask;
	public float search_radius = 5.0f;
	public AnimationCurve falloff;

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        // TODO 1: Agents much separate from each other:
        // 1- Find other agents in the vicinity (use a layer for all agents)

        Collider[] collisions = Physics.OverlapSphere(transform.position, search_radius, mask);
        // 2- For each of them calculate a escape vector using the AnimationCurve
        // 3- Sum up all vectors and trim down to maximum acceleration

        Vector3 repulsion = Vector3.zero;
        foreach (Collider coll in collisions){            
            Vector3 distance = transform.position - coll.transform.position;
            Vector3 vel = distance.normalized * move.max_mov_acceleration;
            repulsion += vel;                 
        }
        repulsion = repulsion.normalized * move.max_mov_acceleration;
        repulsion.y = 0;

        move.AccelerateMovement(repulsion);

	}

	void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, search_radius);
	}
}
