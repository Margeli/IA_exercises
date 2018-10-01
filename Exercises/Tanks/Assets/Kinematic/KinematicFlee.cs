using UnityEngine;
using System.Collections;

public class KinematicFlee : MonoBehaviour {

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        // TODO 6: To create flee just switch the direction to go


        float x =transform.position.x - move.target.transform.position.x;
        float z =transform.position.z - move.target.transform.position.z;

        Vector3 vec = new Vector3(x, 0, z);
        move.SetMovementVelocity(vec.normalized * move.max_mov_velocity);

    }
}
