using UnityEngine;
using UnityEngine.AI;

public class enemymovement : MonoBehaviour
{
    
    private NavMeshAgent nav;
    
    public Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        stunStatic.gameObject.SetActive(false);
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
                stunStatic.gameObject.SetActive(false);
            }
        }
        
    }

    //stun controlls
    private bool stuned = false;
    private float stunTimer = 0.0f;
    public float StunRecover = 3;

    public GameObject stunStatic;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shockwave"))
        {
            stuned = true;
            stunStatic.gameObject.SetActive(true);
        }
    }
}
