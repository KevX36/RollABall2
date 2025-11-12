using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.ProBuilder.Shapes;

public class ShootingEnemyControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public GameObject bullet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        stunStatic.gameObject.SetActive(false);
    }
    private float shotTimer = 0;
    public float shotCoolDown = 2;
    // Update is called once per frame
    void Update()
    {
        if (stuned == false)
        {
            if (player != null)
            {
                Vector3 aim = player.transform.position - transform.position;
                transform.rotation = Quaternion.LookRotation(aim);
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
        //shot timer
        shotTimer += Time.deltaTime;
    }
}
