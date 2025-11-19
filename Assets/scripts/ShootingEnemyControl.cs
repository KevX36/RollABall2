using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.ProBuilder.Shapes;

public class ShootingEnemyControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public GameObject bullet;
    public float shotSpeed = 4;
    private Rigidbody rb;
    Vector3 shot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = bullet.gameObject.GetComponent<Rigidbody>();
        stunStatic.gameObject.SetActive(false);
    }
    private float shotTimer = 0;
    public int shotCoolDown = 2;
    public float reload = 2;
    
    
    // Update is called once per frame
    void Update()
    {
        if (stuned == false)
        {
            if (shotTimer < shotCoolDown)
            {
                if (player != null)
                {
                    Vector3 aim = player.transform.position - transform.position;
                    transform.rotation = Quaternion.LookRotation(aim);

                }
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
        //shot timer
        shotTimer += Time.deltaTime;
        bullet.transform.rotation = transform.rotation;

        if (shotTimer >= shotCoolDown)
        {
            bullet.gameObject.SetActive(true);
            
            shot = transform.forward;
                
            
            
            rb.AddForce(shot*shotSpeed);
            
            
        }


        if (shotTimer >= shotCoolDown + reload)
        {
            rb.angularVelocity=new Vector3(0,0,0);
            rb.linearVelocity = new Vector3(0, 0, 0);
            bullet.transform.position = transform.position;
            shotTimer = 0;
            

            bullet.gameObject.SetActive(false);
            


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
    private void shoot()
    {

    }
}
