using UnityEngine;
using UnityEngine.AI;

public class enemymovement : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent nav;
    private bool stuned = false;
    private float stunTimer = 0.0f;
    public float StunRecover = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stuned == false)
        {
            if (player != null)
            {
                nav.SetDestination(player.position);
            }
        }
        if (stuned == true)
        {
            stunTimer += Time.deltaTime;
            if (stunTimer >= StunRecover)
            {
                stuned = false;
                stunTimer = 0.0f;
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("shockwave"))
        {
            stuned = true;
        }
    }
}
