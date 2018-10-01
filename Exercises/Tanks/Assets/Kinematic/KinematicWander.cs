using UnityEngine;
using System.Collections;

public class KinematicWander : MonoBehaviour {

	public float max_angle = 0.5f;
    public float frequency = 1.0f;
    private float prev_freq;

    Move move;
    

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
        prev_freq = frequency;
	}

	// number [-1,1] values around 0 more likely
	float RandomBinominal()
	{
		return Random.value * Random.value;
	}
	
	// Update is called once per frame
	void Update () 
	{
        //TODO 9: Generate a velocity vector in a random rotation(use RandomBinominal) and some attenuation factor

        frequency -= Time.deltaTime;
        if (frequency <= 0.0f)
        {
            Vector3 rotation = new Vector3(0, 180 * RandomBinominal());
            move.transform.Rotate(rotation);
            frequency = prev_freq;
        }


    }
}
