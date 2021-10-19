using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Pause : MonoBehaviour
{
    public void ButtonClick_PauseGame()
    {        
        Time.timeScale = 0;       
    }

    public void ButtonClick_ResumeGame()
    {
        Time.timeScale = 1;       
    }

    public void ButtonClick_ReturnToMainMenu()
    {
        ButtonClick_ResumeGame();
        SceneManager.LoadScene(0);
    }
}
