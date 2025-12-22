
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Runtime.CompilerServices;
using System;
using System.Threading;

public class PlayerContoller : MonoBehaviour
{
    
    public GameObject self;
    
    public GameObject goal;
    
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public Material color;
    
   
    private float baseSpeed;
    public int goalTarget = 0;
    public int abilities = 3;
    
    private float timer = 0.0f;
    bool levelOver = false;
    

    //text and text releated
    public GameObject nextLVText;
    public GameObject youwin;
    public GameObject RestartAndQuitText;
    public GameObject dashText;
    public GameObject shieldText;
    public GameObject shockWaveText;
    public float speed = 0;
    private int score = 0;
    public TextMeshProUGUI scoretext;
    public GameObject timerText;





    //dash releated
    public int dashCap = 3;
    private int dashCount;
    public float dashBoost = 0;
    private bool shieldReady = true;
    private bool candash = true;
    private float dashTimer = 0.0f;
    public float dashCoolDown = 1.0f;
    

    //Shield releated
    
    public float shieldTimer = 0.0f;
    public GameObject weakShield;
    public GameObject shield;
    
    
    
    public float shieldEnd = 2.0f;
    
    
    bool shieldOn = false;
    
    //shock releated
    private int shockCount;
    public int shockCap = 3;
    public float shockTimer = 0.0f;
    public float shockCooldown = 5;
    
    private bool shockUsed = false;
    
    public GameObject shock;
    
    public float shockactive = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dashCount = dashCap;
        shockCount = shockCap;
        baseSpeed = speed;
        goal.SetActive(false);
        RestartAndQuitText.SetActive(false);
        nextLVText.gameObject.SetActive(false);
        rb = GetComponent<Rigidbody>();
        SetScoreText();
        youwin.SetActive(false);
        RestartAndQuitText.gameObject.SetActive(false);
        shield.SetActive(false);
        timerText.GetComponent<TextMeshProUGUI>().text = $"{timer}";
        shock.gameObject.SetActive(false);
        //sets color as normal
        color.color = new Color32(131, 255, 255, 255);
    }
    
    void OnMove(InputValue movementValue)
    {

        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
        

    }

    void SetScoreText()
    {

        scoretext.text = "Score:" + score.ToString();
        if (score >= goalTarget)
        {
            goal.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
        if (speed > baseSpeed)
        {
            speed--;
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            score++;
            SetScoreText();
        }
        
        if (other.gameObject.CompareTag("Goal"))
        {
            nextLVText.gameObject.SetActive(true);
            levelOver = true;
            self.gameObject.SetActive(false);
            dashText.gameObject.SetActive(false);
            shieldText.gameObject.SetActive(false);
            shockWaveText.gameObject.SetActive(false);
            
            youwin.gameObject.SetActive(true);
        }
        //ability recharges
        if (other.gameObject.CompareTag("rechargeDash"))
        {
            
            dashCount = dashCap;
            dashText.GetComponent<TextMeshProUGUI>().text = $"Dashs: {dashCount}";
        }
        if (other.gameObject.CompareTag("rechargeShield"))
        {

            shieldReady = true;
            shieldText.GetComponent<TextMeshProUGUI>().text = $"Shield: ready";
        }
        if (other.gameObject.CompareTag("rechargeShock"))
        {

            
            shockCount = shockCap;
            
            shockWaveText.GetComponent<TextMeshProUGUI>().text = $"Shocks: {shockCount}";
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (shieldOn == false)
        {
            if (collision.gameObject.CompareTag("enemy"))
            {
                Debug.Log("colided with enemy");
                Destroy(self);

                youwin.gameObject.SetActive(true);
                youwin.GetComponent<TextMeshProUGUI>().text = "You Lose!";
                RestartAndQuitText.gameObject.SetActive(true);
                dashText.gameObject.SetActive(false);
                shieldText.gameObject.SetActive(false);
                shockWaveText.gameObject.SetActive(false);

            }
        }
        if (collision.gameObject.CompareTag("BIG enemy"))
        {
            Debug.Log("colided with enemy");
            Destroy(self);

            youwin.gameObject.SetActive(true);
            youwin.GetComponent<TextMeshProUGUI>().text = "You Lose!";
            RestartAndQuitText.gameObject.SetActive(true);
            dashText.gameObject.SetActive(false);
            shieldText.gameObject.SetActive(false);
            shockWaveText.gameObject.SetActive(false);

        }
    }
   
    void Update()
    {
        //lose if you fall
        if (self.transform.position.y < -20)
        {
            Destroy(self);

            youwin.gameObject.SetActive(true);
            youwin.GetComponent<TextMeshProUGUI>().text = "You Lose!";
            RestartAndQuitText.gameObject.SetActive(true);
            dashText.gameObject.SetActive(false);
            shieldText.gameObject.SetActive(false);
            shockWaveText.gameObject.SetActive(false);
        }
        //timers
        timer += Time.deltaTime;
        shieldTimer += Time.deltaTime;
        shockTimer += Time.deltaTime;
        
        if (levelOver == false)
        {
            timerText.GetComponent<TextMeshProUGUI>().text = $"{System.Math.Round(timer, 2)}";
        }
        //dash
        dashTimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (candash == true)
            {
                if (dashCount > 0)
                {

                    speed = speed * dashBoost;

                    dashCount--;
                    candash = false;
                    dashText.GetComponent<TextMeshProUGUI>().text = $"Dashs: {dashCount}";
                    dashTimer = 0.0f;
                    //change color to be lighter
                    color.color = new Color32(213, 255, 255, 255);
                    if (shockUsed == true)
                    {
                        //change color to be grayer instead
                        color.color = new Color32(137, 174, 174, 255);
                    }
                }
            }
        }
        if (dashTimer >= dashCoolDown)
        {
            candash = true;
            //return color to normal
            color.color = new Color32(131, 255, 255, 255);
            if (shockUsed == true)
            {
                //make color go from gray to dark instead
                color.color = new Color32(88, 178, 178, 255);
            }
        }
        //shield
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (abilities > 1)
            {
                if (shieldReady == true)
                {
                    shieldTimer = 0.0f;
                    shield.SetActive(true);
                    shieldOn = true;
                    shieldText.GetComponent<TextMeshProUGUI>().text = $"Shield: active";
                    shieldReady = false;
                }
            }


        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (abilities > 1)
            {
                if (shieldReady == true)
                {
                    shieldText.GetComponent<TextMeshProUGUI>().text = $"Shield: online";
                    shieldTimer = 0.0f;
                    shield.SetActive(true);
                    shieldOn = true;
                    
                    shieldReady = false;
                }
            }

        }
        if (shieldTimer >= shieldEnd - 0.5f)
        {
            if (shieldOn == true)
            {
                shield.SetActive(false);
                weakShield.SetActive(true);
            }
        }
        if (shieldTimer >= shieldEnd)
        {
            if (shieldOn == true)
            {
                weakShield.SetActive(false);
                shieldOn = false;
                if (shieldReady == false)
                {
                    shieldText.GetComponent<TextMeshProUGUI>().text = $"Shield: offline";
                }
            }
        }
        //shock
        if (abilities > 2)
        {
            if (shockUsed == false)
            {
                if (shockCount > 0)
                {
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        shock.gameObject.SetActive(true);
                        shockTimer = 0;
                        shockUsed = true;
                        shockCount--;
                        shockWaveText.GetComponent<TextMeshProUGUI>().text = $"Shocks: {shockCount}";
                    }
                    if (Input.GetKeyDown(KeyCode.B))
                    {
                        shock.gameObject.SetActive(true);
                        shockTimer = 0;
                        shockUsed = true;
                        shockCount--;
                        shockWaveText.GetComponent<TextMeshProUGUI>().text = $"Shocks: {shockCount}";
                    }
                }
            }
        }
        
        
        
        if (shockUsed == true)
        {
            if (shockTimer >= shockactive)
            {
                shock.gameObject.SetActive(false);
                //set color to be darker
                color.color = new Color32(88, 178, 178, 255);
                if (candash == false)
                {
                    //make it grayer instead
                    color.color = new Color32(137, 174, 174, 255);
                }
            }
            if (shockTimer >= shockCooldown)
            {
                shockUsed = false;
                shockTimer = 0;
                //return color to normal
                color.color = new Color32(131, 255, 255, 255);
                if (candash == false)
                {
                    //color just becomes lighter instead
                    color.color = new Color32(213, 255, 255, 255);
                }
            }
        }
        
        
    }
}
