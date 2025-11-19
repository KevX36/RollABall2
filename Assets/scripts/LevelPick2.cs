using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPick2 : MonoBehaviour
{
     public void LoadLevel1()
     {
        SceneManager.LoadScene("RollABall2-level-1");
     }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("level2");
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene("level3");
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene("level4");
    }
    public void LoadLevel5()
    {
        SceneManager.LoadScene("level5");
    }
    public void LoadControls()
    {
        SceneManager.LoadScene("controls");
    }
    public void LoadItems()
    {
        SceneManager.LoadScene("objectInfo");
    }
    public void loadMainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
