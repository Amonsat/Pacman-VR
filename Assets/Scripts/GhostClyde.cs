using UnityEngine;
using System.Collections;

public class GhostClyde : MonoBehaviour
{
    // public Transform target;
    public float startDelay;
    public Vector3 homePoint;

    private float startDelayOffset; 
    private NavMeshAgent agent;
    private Transform target;
    private Vector3 defaultPosition;

    void Start()
    {
        defaultPosition = transform.position;
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        startDelayOffset = startDelay;
    }

    void Update()
    {
        if (GameManager.instance.isMenu) 
        {
            agent.destination = transform.position;
            return;
        }
        
    	if ((Time.time < startDelayOffset)) return;
    	// print(Time.time);
        var distance = Vector3.Distance(target.position, transform.position);
        
        if ( distance > 90 ) agent.destination = target.position;
        else agent.destination = homePoint;
    }
    
    public void Reset()
    {
        agent.enabled = false;
        transform.position = defaultPosition;
        // transform.Translate(defaultPosition);
        startDelayOffset = startDelay + Time.time;
        // print("delay: " + startDelay + " Time: " + Time.time);
        agent.enabled = true;
    }
}
