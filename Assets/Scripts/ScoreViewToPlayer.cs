using UnityEngine;
using System.Collections;

public class ScoreViewToPlayer : MonoBehaviour 
{    
	// Update is called once per frame
	void Update () 
    {
        // var targetRotation = transform;
        // targetRotation.LookAt(Camera.main.transform);
	    // transform.eulerAngles = new Vector3(transform.eulerAngles.x, targetRotation.eulerAngles.y, transform.eulerAngles.z);
        transform.LookAt(Camera.main.transform);
	}
}
