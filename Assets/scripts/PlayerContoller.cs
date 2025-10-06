
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Runtime.CompilerServices;
using System;

public class PlayerContoller : MonoBehaviour
{
    private bool hitgoal = false;
    public GameObject self;
    public GameObject goal;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 0;
    private int score = 0;
    public TextMeshProUGUI scoretext;
    public GameObject youwin;
    public GameObject RestartAndQuitText;
    private bool canDash = true;
    public GameObject dashTutorial;
    public GameObject Dashtext;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        goal.SetActive(false);
        RestartAndQuitText.SetActive(false);
        rb = GetComponent<Rigidbody>();
        SetScoreText();
        youwin.SetActive(false);
        RestartAndQuitText.gameObject.SetActive(false);
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
        if (score >= 12)
        {
            goal.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
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
            
            youwin.gameObject.SetActive(true);
        }

        if (other.gameObject.CompareTag("rechargeDash"))
        {
            Dashtext.GetComponent<TextMeshProUGUI>().text = "Dash: online";
            canDash = true;
            
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("colided with enemy");
            Destroy(self);
            
            youwin.gameObject.SetActive(true);
            youwin.GetComponent<TextMeshProUGUI>().text = "You Loss, HA HA!";
            RestartAndQuitText.gameObject.SetActive(true);
            Dashtext.gameObject.SetActive(false);
            
        }
    }
   
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canDash == true)
            {
                dashTutorial.SetActive(false);
                
                speed = speed * 2;

                speed = speed / 2;
                canDash = false;
                Dashtext.GetComponent<TextMeshProUGUI>().text = "Dash: offline";
            }
        }
    }
}
