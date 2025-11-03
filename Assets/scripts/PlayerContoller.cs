
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Runtime.CompilerServices;
using System;
using System.Threading;

public class PlayerContoller : MonoBehaviour
{
    private bool hitgoal = false;
    public GameObject self;
    public GameObject nextLVText;
    public GameObject goal;
    public GameObject shield;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 0;
    private int score = 0;
    public TextMeshProUGUI scoretext;
    public GameObject youwin;
    public GameObject RestartAndQuitText;
    public GameObject dashText;
    public GameObject shieldText;
    public GameObject shockWaveText;
    private float baseSpeed;
    public int goalTarget = 0;
    public int abilities = 3;
    public GameObject timerText;
    private float timer = 0.0f;
    bool levelOver = false;
    public GameObject weakShield;



    //dash
    public int dashCap = 3;
    private int dashCount;
    public float dashBoost = 0;
    private bool shieldReady = true;
    private bool candash = true;
    private float dashTimer = 0.0f;
    public float dashCoolDown = 1.0f;


    //Shield
    
    public float shieldTimer = 0.0f;
    
    
    
    
    
    public float shieldEnd = 2.0f;
    
    
    bool shieldOn = false;
    
    //shock
    public int shockCount = 0;
    public int shockCap = 3;
    public float shockTimer = 1;
    public float shockCooldown = 5;
    private bool shockRecharge = true;
    private bool shockUsed = false;
    public int shockRechargeReady=5;

    public float colorChangeTimer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dashCount = dashCap;
        baseSpeed = speed;
        goal.SetActive(false);
        RestartAndQuitText.SetActive(false);
        nextLVText.SetActive(false);
        rb = GetComponent<Rigidbody>();
        SetScoreText();
        youwin.SetActive(false);
        RestartAndQuitText.gameObject.SetActive(false);
        shield.SetActive(false);
        timerText.GetComponent<TextMeshProUGUI>().text = $"{timer}";
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
            levelOver = true;
            self.gameObject.SetActive(false);
            dashText.gameObject.SetActive(false);
            shieldText.gameObject.SetActive(false);
            shockWaveText.gameObject.SetActive(false);
            nextLVText.SetActive(true);
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
        if (shockRecharge == true)
        {
            if (other.gameObject.CompareTag("rechargeShock"))
            {
                shockCount++;
                if (shockCount > shockCap)
                {
                    shockCount = shockCap;
                }
                shockRecharge = false;
            }
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
        
    }
   
    void Update()
    {
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
        timer += Time.deltaTime;
        shieldTimer += Time.deltaTime;
        shockTimer += Time.deltaTime;
        colorChangeTimer += Time.deltaTime;
        if (levelOver == false)
        {
            timerText.GetComponent<TextMeshProUGUI>().text = $"{System.Math.Round(timer, 2)}";
        }
        
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
                }
            }
        }
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
        if (dashTimer >= dashCoolDown)
        {
            candash = true;
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
        if (shockUsed == false)
        {
            if (shockTimer == shockRechargeReady)
            {
                shockRecharge = true;
                shockTimer = 0;
            }
        }
        
    }
}
