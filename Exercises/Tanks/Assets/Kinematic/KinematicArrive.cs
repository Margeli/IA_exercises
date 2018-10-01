using UnityEngine;
using System.Collections;

public class KinematicArrive : MonoBehaviour {

	public float min_distance = 0.1f;
	public float time_to_target = 0.25f;

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}

	// Update is called once per frame
	void Update () 
	{
        // TODO 8: calculate the distance. If we are in min_distance radius, we stop moving
        // Otherwise devide the result by time_to_target (0.25 feels good)
        // Then call move.SetMovementVelocity()
        Vector3 dist = new Vector3(move.target.transform.position.x - transform.position.x,0,  move.target.transform.position.z - transform.position.z);
        Vector3 vel;
        if (dist.magnitude <= min_distance)
        {
            vel = Vector3.zero;

        }
        else {
            vel = dist / time_to_target;

        }
        move.SetMovementVelocity(vel);

    }

	void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, min_distance);
	}
}
