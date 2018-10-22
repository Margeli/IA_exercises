using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Components;

public class FollowCurve : MonoBehaviour
{
    float currentRatio = 0.0f;
    
    public BGCcMath path;
    public float step = 0.01f;


    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // TODO 1: Have a GameObject that follows the curve's path
        // Increase the ratio [0 to 1] and set the GameObject position to the respecive point in the curve
        if (currentRatio > 1.0f) {
            currentRatio = 0;
        }
       transform.position = path.CalcPositionByDistanceRatio(currentRatio); 
        currentRatio+=step;

	}
}
