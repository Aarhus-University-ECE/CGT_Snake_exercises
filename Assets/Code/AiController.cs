using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiController : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        //VERY very simple AI based on navmesh
        //Another implementation that might work better would be to have states for it, where 
        //Patrol // chase // Idle states could be achieved. each with their own behaviour, and then activate chase if snake is
        //within some boundary of the Zombie


        //(HINT, it is a oneliner, that makes the agent pathfind towards the player)
        //TODO 

    }

}
