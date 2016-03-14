using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour
{
    // public Transform target;
    public float startDelay;
    public float forwardOffset = 0;
    public Color color;

    NavMeshAgent agent;
    Transform target;

    void Awake()
    {
        //agent = GetComponent<NavMeshAgent>();
    }

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

    void OnDrawGizmos()
    {
        //if (agent.destination == null) return;
        //Gizmos.color = color;
        //Gizmos.DrawLine(transform.position, target.position + target.transform.forward * forwardOffset);
    }
}
