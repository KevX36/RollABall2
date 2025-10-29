using UnityEngine;
using UnityEngine.AI;

public class ShootingEnemyControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }
    public Transform player;
    private NavMeshAgent nav;
    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            
        }
    }
}
