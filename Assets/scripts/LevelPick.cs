using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class levelPick : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform != null)
                {
                    levelclicked(hit.transform.gameObject);
                }
            }
        }
    }
    public void levelclicked(GameObject level)
    {
        
        if (level.tag == "Lv1")
        {
            SceneManager.LoadScene("RollABall2-level-1");
        }
        if (level.tag == "Lv2")
        {
            SceneManager.LoadScene("level2");
        }
        if (level.tag == "Lv3")
        {
            SceneManager.LoadScene("level3");
        }
        if (level.tag == "controls")
        {
            SceneManager.LoadScene("controls");
        }
        if (level.tag == "objects")
        {
            SceneManager.LoadScene("objectInfo");
        }

    }
}
