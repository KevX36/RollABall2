using UnityEngine;

public class tutorial_text : MonoBehaviour
{
    public GameObject Tutorial;
    public int tutorialType = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (tutorialType == 0)
        {
            Tutorial.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorialType == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Tutorial.gameObject.SetActive(false);
            }
        }
        
    }
}
