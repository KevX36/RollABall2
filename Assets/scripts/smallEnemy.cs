using UnityEngine;
using UnityEngine.AI;

public class smallEnemy : MonoBehaviour
{
    private NavMeshAgent nav;

    public Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            nav.SetDestination(player.position);
        }
    }

    //stun controlls
    

    
}
