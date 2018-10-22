﻿using UnityEngine;
using System.Collections;

public class KinematicSeek : SteeringAbstract {

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 diff = move.target.transform.position - transform.position;
		diff.Normalize ();
		diff *= move.max_mov_velocity;

		move.SetMovementVelocity(diff, priority);
	}
}
