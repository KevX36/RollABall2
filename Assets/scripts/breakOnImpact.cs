using UnityEngine;

public class BreakOnImpact : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public GameObject self;
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit something");
        if (!collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("hit a non enemy");
            self.gameObject.SetActive(false);
        }
        
    }
    
}
