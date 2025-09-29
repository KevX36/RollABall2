using UnityEngine;
using UnityEngine.AI;

public class enemymovement : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent nav;
    
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
}
