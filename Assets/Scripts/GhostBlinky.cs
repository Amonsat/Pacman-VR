using UnityEngine;
using System.Collections;

public class GhostBlinky : MonoBehaviour
{
    // public Transform target;
    public float startDelay;    
    
    private NavMeshAgent agent;
    private Transform target;
    private Vector3 defaultPosition;
    private float startDelayOffset;

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
        agent.destination = target.position;
    }
    
    public void Reset()
    {
        agent.enabled = false;
        transform.position = defaultPosition;
        // transform.Translate(defaultPosition);
        startDelayOffset = startDelay + Time.time;
        agent.enabled = true;
    }

}
