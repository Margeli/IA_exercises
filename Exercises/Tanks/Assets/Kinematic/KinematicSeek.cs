using UnityEngine;
using System.Collections;

public class KinematicSeek : MonoBehaviour {

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}

    // Update is called once per frame
    void Update()
    {
        // TODO 5: Set movement velocity to max speed in the direction of the target

        float x = move.target.transform.position.x - transform.position.x;
        float z = move.target.transform.position.z - transform.position.z;

        Vector3 vec = new Vector3(x, 0, z);
        move.SetMovementVelocity(vec.normalized * move.max_mov_velocity);

        // Remember to enable this component in the inspector
    }
}
