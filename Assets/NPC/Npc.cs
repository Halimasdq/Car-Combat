using UnityEngine;
using UnityEngine.AI;

public class npc : MonoBehaviour
{
    public Transform roadStart;    // Reference to the starting point of the road.
    public Transform roadEnd;      // Reference to the ending point of the road.
    private NavMeshAgent agent;

    private void Start()
    {
        // Get the NavMeshAgent component attached to the cube.
        agent = GetComponent<NavMeshAgent>();

        // Set the cube's initial position on the road start.
        agent.Warp(roadStart.position);

        // Set the cube's destination to the road end.
        agent.SetDestination(roadEnd.position);
    }
}
