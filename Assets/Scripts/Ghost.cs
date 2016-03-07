using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;

    void Awake()
    {
        //agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
    }

    void Update()
    {
        agent.destination = target.position;
    }
}
