using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perception : MonoBehaviour {


    public float radius = 2.0f;
    public LayerMask mask;
    public LayerMask rayMask;

    public Camera camera;
    Vector3 target;

    bool detected = false;
    

    // Use this for initialization
    void Start () {

        camera = transform.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {



        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, mask);
        Plane[] cameraPlanes = GeometryUtility.CalculateFrustumPlanes(camera);

        foreach (Collider coll in colliders) {
            if (coll.gameObject != this.gameObject ) {

                if (GeometryUtility.TestPlanesAABB(cameraPlanes, coll.bounds))
                {

                    //Debug.Log("Detected ma men");

                    Vector3 dir = coll.transform.position - transform.position;

                    target = coll.transform.position;


                    if (Physics.Raycast(transform.position, target, rayMask)) {
                        Debug.Log("I SEE U :)");
                        

                    }                 
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
       
        Gizmos.DrawLine(transform.position, target);

    }
}
