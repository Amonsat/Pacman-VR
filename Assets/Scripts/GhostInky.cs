using UnityEngine;
using System.Collections;

public class GhostInky : MonoBehaviour
{
    // public Transform target;
    public float startDelay;
    public float forwardOffset = 2;
    public Transform blinkyLink;

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
        
        var targetPoint = (target.position + target.transform.forward * forwardOffset) - blinkyLink.position + target.position;        
        
    	if ((Time.time < startDelay)) return;
    	// print(Time.time);
        
        agent.destination = targetPoint;
    }    

}
