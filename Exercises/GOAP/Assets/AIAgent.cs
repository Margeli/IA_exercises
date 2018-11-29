using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class AIAgent : MonoBehaviour , IGoap{


    public List<Condition> state { get; set; }
    public List<Goal> availableGoals { get; set; }
    public List<Action> availableActions { get; set; }


    private void Awake()
    {
        state = new List<Condition>();
        availableGoals = new List<Goal>();
        availableActions = new List<Action>();

        foreach (Goal g in availableGoals)
            g.OnGoalInitialize(this);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
