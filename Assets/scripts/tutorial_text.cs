using System.Threading;
using System.Timers;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class tutorial_text : MonoBehaviour
{
    public GameObject Tutorial;
    public int tutorialType = 0;
    public int showAbillites = 0;
    public GameObject shieldText;
    public GameObject jumpText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (tutorialType == 0)
        {
            Tutorial.gameObject.SetActive(false);
        }
        if (tutorialType == 2)
        {
            Tutorial.GetComponent<TextMeshProUGUI>().text = "press E or V to active your shield";
        }
        if (showAbillites > 0)
        {
            jumpText.SetActive(false);
            if (showAbillites > 1)
            {
                shieldText.SetActive(false);
            }
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
        if (tutorialType == 2)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {

                timer = 0.0f;
                Tutorial.SetActive(true);
                Tutorial.GetComponent<TextMeshProUGUI>().text = "go into the pink cube to recharge your shield";
                closeTutorial = true;
            }
        }
        if (tutorialType == 2)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                timer = 0.0f;
                Tutorial.SetActive(true);
                Tutorial.GetComponent<TextMeshProUGUI>().text = "go into the pink cube to recharge your shield";
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
