using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLvOrRTMM : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public int nextLV =0;
    public GameObject Self;
    // Update is called once per frame
    void Update()
    {
        if (nextLV > 0)
        {
            if (nextLV == 2) 
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    SceneManager.LoadScene("level2");
                }
            }
            else if (nextLV == 3)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    SceneManager.LoadScene("level3");
                }
            }
            else if (nextLV == 4)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    SceneManager.LoadScene("level4");
                }
            }
            else if (nextLV == 5)
            {
                if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    SceneManager.LoadScene("level5");
                }
            }

        }
        else
        {
            Self.GetComponent<TextMeshProUGUI>().text = "Press 2 to return to main menu";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("mainMenu");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
