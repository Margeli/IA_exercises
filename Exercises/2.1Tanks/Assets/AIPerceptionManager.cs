using UnityEngine;
using System.Collections;

public class AIPerceptionManager : MonoBehaviour {

	public GameObject Alert;
    AIMemory memory;

    private void Start()
    {
        memory = GetComponent<AIMemory>();
    }
    // Update is called once per frame
    void PerceptionEvent (PerceptionEvent ev) {

		if(ev.type == global::PerceptionEvent.types.NEW)
		{

            memory.AddBlackBoardEntry(ev.go);
			Debug.Log("Saw something NEW");
			Alert.SetActive(true);
		}
		else // type == OLD
		{
            memory.UpdateBlackBoardEntry(ev.go, true);
			Debug.Log("LOST something");
			Alert.SetActive(false);
		}
	}
}
