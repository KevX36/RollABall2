
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
    private int dashCount = 3;
    private bool shieldReady = true;
    public GameObject dashText;
    public GameObject shieldText;
    private float baseSpeed;
    public float dashBoost = 0;
    public int goalTarget = 0;
    public float shieldTimer = 0.0f;
    public int abilities = 3;
    private bool candash = true;
    private float dashTimer = 0.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        baseSpeed = speed;
        goal.SetActive(false);
        RestartAndQuitText.SetActive(false);
        rb = GetComponent<Rigidbody>();
        SetScoreText();
        youwin.SetActive(false);
        RestartAndQuitText.gameObject.SetActive(false);
        shield.SetActive(false);
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
            self.gameObject.SetActive(false);
            dashText.gameObject.SetActive(false);
            shieldText.gameObject.SetActive(false);
            youwin.gameObject.SetActive(true);
        }

        if (other.gameObject.CompareTag("rechargeDash"))
        {
            
            dashCount = 3;
            dashText.GetComponent<TextMeshProUGUI>().text = $"Dashs: {dashCount}";
        }

    }
    void OnCollisionEnter(Collision collision)
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

        }
    }
   
    void Update()
    {
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
        if (dashTimer >= 1.0f)
        {
            candash = true;
        }
    }
}
