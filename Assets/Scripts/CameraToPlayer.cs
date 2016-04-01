using UnityEngine;
using System.Collections;

public class CameraToPlayer : MonoBehaviour 
{
    public Transform player;
	
	// Update is called once per frame
	void Update () 
    {
	    var targetPosition = player.position;
        targetPosition.y = 244;
        transform.position = targetPosition;
	}
}
