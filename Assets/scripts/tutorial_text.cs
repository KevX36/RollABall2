using System.Threading;
using System.Timers;
using TMPro;
using Unity.VisualScripting;
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
    static float timer = 0.0f;
    static bool closeTutorial = false;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (tutorialType == 0)
        {
            Tutorial.SetActive(false);
        }
        if (tutorialType == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                timer = 0.0f;
                Tutorial.SetActive(true);
                Tutorial.GetComponent<TextMeshProUGUI>().text = "go into the blue cube to recharge your dashs";
                closeTutorial = true;
            }
        }
        if (closeTutorial == true)
        {
            if (timer >= 3.0f)
            {
                timer = 0.0f;
                Tutorial.SetActive(false);
            }
        }
        
    }
    
}//
