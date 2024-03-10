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

        // set random speed of the npc car
        agent.speed = Random.Range(3.5f, 10);

        //Debug.Log(agent.name + " " + agent.speed);

        // set random handling of the npc car


        // Set the cube's initial position on the road start.
        agent.Warp(roadStart.position);

        // Set the cube's destination to the road end.
        agent.SetDestination(roadEnd.position);
    }
}
