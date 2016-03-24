using UnityEngine;
using System.Collections;

public class GhostInky : MonoBehaviour
{
    // public Transform target;
    public float startDelay;
    public float forwardOffset = 2;
    public Transform blinkyLink;
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
        
        var targetPoint = (target.position + target.transform.forward * forwardOffset) - blinkyLink.position + target.position;        
        
    	if ((Time.time < startDelayOffset)) return;
    	// print(Time.time);
        
        if (GameManager.instance.huntMode) 
        {
            agent.destination = homePoint;
            return;
        }
        
        agent.destination = targetPoint;
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
