using UnityEngine;

public class GhostWander : MonoBehaviour
{
    enum GhostState
    {
        WANDERING,  
        CHASING     
    };

    GhostState state = GhostState.WANDERING;

    GameObject player; 

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "player")
        {
            state = GhostState.CHASING;
            player = other.gameObject;
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();

        if (state == GhostState.WANDERING)
        {
            if (agent.remainingDistance <= 1.0f)
                {
                    float x = Random.Range(-20.0f, 20.0f);
                    float z = Random.Range(-20.0f, 20.0f);
                    agent.destination = new Vector3(x, 0.0f, z);
                }
        }
        else if (state == GhostState.CHASING)
        {
            agent.destination = player.transform.position;
            agent.speed = 7f;
        }
    }

    
}
