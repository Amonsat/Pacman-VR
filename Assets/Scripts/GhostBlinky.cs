using UnityEngine;
using System.Collections;

public class GhostBlinky : MonoBehaviour
{
    // public Transform target;
    public float startDelay;    

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
        agent.destination = target.position;
    }

}
