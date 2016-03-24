using UnityEngine;
using System.Collections;

public class GhostPinky : MonoBehaviour
{
    // public Transform target;
    public float startDelay;
    public float forwardOffset = 4;
    public Vector3 homePoint;

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
        
        if (GameManager.instance.huntMode) 
        {
            agent.destination = homePoint;
            return;
        }
        
        agent.destination = target.position + target.transform.forward * forwardOffset;
        
        
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
