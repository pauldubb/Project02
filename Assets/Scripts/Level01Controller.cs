using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    public GameObject menu;
    public Player player;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void ExitLevel()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        if(player.GetScore() > highScore)
        {
            PlayerPrefs.SetInt("HighScore", player.GetScore());
            UnityEngine.Debug.Log("New high score: " + player.GetScore().ToString());
        }
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
