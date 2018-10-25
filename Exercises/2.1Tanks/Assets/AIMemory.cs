using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// TODO 1: Create a simple class to contain one entry in the blackboard
// should at least contain the gameobject, position, timestamp and a bool
// to know if it is in the past memory

public class BBEntry {

  
    public  GameObject gameObject;
    public Vector3 position;
    public float timeDetected =0;
    public bool IsPastInMem = false;
}

public class AIMemory : MonoBehaviour {

	public GameObject Cube;
	public Text Output;
   

    // TODO 2: Declare and allocate a dictionary with a string as a key and
    // your previous class as value

    Dictionary<string, BBEntry> blackboard;

	// TODO 3: Capture perception events and add an entry if the player is detected
	// if the player stop from being seen, the entry should be "in the past memory"
    public void AddBlackBoardEntry(GameObject detectedGO)
    {
        BBEntry empty;
        if (blackboard.TryGetValue(detectedGO.name, out empty)) { // checks if already exists

            UpdateBlackBoardEntry(detectedGO, false);
            return;
        }


        BBEntry nwEntry = new BBEntry();
        nwEntry.gameObject = detectedGO;
        nwEntry.position = detectedGO.transform.position;
        

        Cube.transform.position = detectedGO.transform.position;
        blackboard.Add(detectedGO.name, nwEntry);
    }

    public void UpdateBlackBoardEntry(GameObject detectedGO, bool inPast) {
        BBEntry entry;

        blackboard.TryGetValue(detectedGO.name, out entry);
        entry.IsPastInMem = inPast;
        
    }
	// Use this for initialization
	void Start () {

        blackboard = new Dictionary<string, BBEntry>() ;

    }
	
	// Update is called once per frame
	void Update () 
	{
        foreach (KeyValuePair<string, BBEntry> entry in blackboard) // update the entry iif is still in vision
        {
            if (entry.Value.IsPastInMem == false)
            {
                entry.Value.position = entry.Value.gameObject.transform.position;
                Cube.transform.position = entry.Value.gameObject.transform.position;
                entry.Value.timeDetected += Time.deltaTime;
            }
            else {
                entry.Value.timeDetected = 0;
            }
            string name = entry.Key.ToString();
            string position = string.Format("  x: {0:0.0} y: {1:0.0} z: {2:0.0}  ", entry.Value.position.x, entry.Value.position.y, entry.Value.position.z);
            string past = "   past: ";
            string time = " time: " + entry.Value.timeDetected.ToString("0.0");
            if (entry.Value.IsPastInMem) { past += "true"; }
            else
            {
                past += "false ";
            }
            Output.text = name + position + time + past;
        }

            // TODO 4: Add text output to the bottom-left panel with the information
            // of the elements in the Knowledge base

           
	}

}
