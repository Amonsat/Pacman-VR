using UnityEngine;
using System.Collections;

public class GhostClyde : MonoBehaviour
{
    // public Transform target;
    public float startDelay;
    
    public Vector3 homePoint;

    NavMeshAgent agent;
    Transform target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (GameManager.instance.isMenu) 
        {
            agent.destination = transform.position;
            return;
        }
        
    	if ((Time.time < startDelay)) return;
    	// print(Time.time);
        var distance = Vector3.Distance(target.position, transform.position);
        
        if ( distance > 90 ) agent.destination = target.position;
        else agent.destination = homePoint;
    }
}
