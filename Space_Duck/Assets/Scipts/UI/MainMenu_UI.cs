using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_UI : MonoBehaviour
{
    public void ButtonClick_StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
