using UnityEngine;
using System.Collections;

public class SteeringArrive : MonoBehaviour {

	public float min_distance = 0.1f;
	public float slow_distance = 5.0f;
	public float time_to_target = 0.1f;

	Move move;

	// Use this for initialization
	void Start () { 
		move = GetComponent<Move>();
	}

	// Update is called once per frame
	void Update () 
	{
		Steer(move.target.transform.position);
	}

	public void Steer(Vector3 target)
	{
		if(!move)
			move = GetComponent<Move>();

        Vector3 direction = target - transform.position;

        //If the distance to the target is less than min_distance just stop moving
        if (direction.magnitude < min_distance)
        {
            move.SetMovementVelocity(Vector3.zero);
            return;
        }

        //Find desired acceleration
        Vector3 desired_velocity = direction.normalized * move.max_mov_velocity;

        //Calculating the slow factor
        if (direction.magnitude < slow_distance)
            desired_velocity *= (direction.magnitude / slow_distance);

        Vector3 desired_accel = desired_velocity - move.movement;
        desired_accel /= time_to_target;

        //Clamp desired acceleration
        if (desired_accel.magnitude > move.max_mov_acceleration)
        {
            desired_accel = desired_accel.normalized * move.max_mov_acceleration;
        }

        move.AccelerateMovement(desired_accel);
    }

	void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, min_distance);

		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, slow_distance);
	}
}
