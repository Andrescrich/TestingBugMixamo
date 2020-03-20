using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SimpleGo : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform destination;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (transform.position != destination.transform.position)
        {
            agent.destination = destination.transform.position;
        }
    }
}
