using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Pause : MonoBehaviour
{
    public void ButtonClick_PauseGame()
    {
        //TODO: This should most likely hook to something like GameManager to pause the game, instead of directly setting the timescale to 0.
        Time.timeScale = 0;       
    }

    public void ButtonClick_ResumeGame()
    {
        Time.timeScale = 1;       
    }

    public void ButtonClick_ReturnToMainMenu()
    {
        //TODO: same for this, call GameManager instead of doing this directly.
        ButtonClick_ResumeGame();
        SceneManager.LoadScene(0);
    }
}
