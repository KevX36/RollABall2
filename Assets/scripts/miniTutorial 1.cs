using UnityEngine;

public class miniTutorial : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public GameObject self;
    public GameObject text;
    public GameObject arrow;
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shockwave"))
        {
            text.gameObject.SetActive(false);
            arrow.gameObject.SetActive(false);
            self.gameObject.SetActive(false);
        }
    }
}
