using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOrQuit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("mainMenu");
        }
       
    }
}
