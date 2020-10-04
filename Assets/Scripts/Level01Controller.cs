using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    [SerializeField] Text _currentScoreTextView;
    

    int _currentScore;
    

    public GameObject menu;

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            IncreaseScore(5);
        }

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
        if(_currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", _currentScore);
            UnityEngine.Debug.Log("New high score: " + _currentScore);
        }
        SceneManager.LoadScene("MainMenu");
    }

    public void IncreaseScore(int scoreIncrease)
    {
        _currentScore += scoreIncrease;
        _currentScoreTextView.text = "Score: " + _currentScore.ToString();
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
