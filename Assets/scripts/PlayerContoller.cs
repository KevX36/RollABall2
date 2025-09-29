
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerContoller : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 0;
    private int score = 0;
    public TextMeshProUGUI scoretext;
    public GameObject youwin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

        rb = GetComponent<Rigidbody>();
        SetScoreText();
        youwin.SetActive(false);
        
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
            youwin.SetActive(true);
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
    }
}
