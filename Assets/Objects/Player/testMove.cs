using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.Networking;

public class testMove : MonoBehaviour
{
    public float speed;
    public Transform targetPosition;

    private Vector3 startPosition;
    private float startTime;
    private float distance;
    private float percentage;

	// Use this for initialization
	void Start ()
	{
	    startPosition = transform.position;
	    startTime = Time.time;
        distance = Vector3.Distance(startPosition, targetPosition.position);
    }
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    if (transform.position == targetPosition.position) return;
	    percentage = ((Time.time - startTime)*speed)/distance;
        transform.position = Vector3.Lerp(startPosition, targetPosition.position, percentage);
    }
}
