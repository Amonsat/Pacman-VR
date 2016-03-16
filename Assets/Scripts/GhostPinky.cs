using UnityEngine;
using System.Collections;

public class GhostPinky : MonoBehaviour
{
    // public Transform target;
    public float startDelay;
    public float forwardOffset = 4;

    NavMeshAgent agent;
    Transform target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
    	if ((Time.time < startDelay)) return;
    	// print(Time.time);
        agent.destination = target.position + target.transform.forward * forwardOffset;
    }

}
