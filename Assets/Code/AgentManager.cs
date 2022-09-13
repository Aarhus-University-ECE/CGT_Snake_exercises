using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentManager : MonoBehaviour
{
    public GameObject agent;
    Bounds starterzone;

    // Start is called before the first frame update
    void Start()
    {
        starterzone = new Bounds(new Vector3(0, (float)0.5, 0), new Vector3(20, (float)0.5, 20));
        //Invokerepeating repeatedly invokes the method spawnNewAgent, starting in 2 seconds, every 5 seconds
        InvokeRepeating("SpawnNewAgent", 2.0f, 5f);
    }
    
    void SpawnNewAgent()
    {
        NavMeshHit hit;
        //dont know what happens if this tries to spawn in navmesh starterzone? Should be avoided with the below code
        //Even though it is not pretty.

        Vector3 randomPos = new Vector3(Random.Range(-45, 45), (float)0.5, Random.Range(-45, 45));
        while (starterzone.Contains(randomPos)){
            randomPos = new Vector3(Random.Range(-45, 45), (float)0.5, Random.Range(-45, 45));
        }
        NavMesh.SamplePosition(randomPos, out hit, Mathf.Infinity, NavMesh.AllAreas);
        agent = Instantiate(agent, hit.position, Quaternion.identity);
    }
}
