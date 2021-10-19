using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_UI : MonoBehaviour
{
    [SerializeField]
    private UI_Settings settingsPanel;

    public void ButtonClick_StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonClick_ShowSettings()
    {
        settingsPanel.Init();
        settingsPanel.gameObject.SetActive(true);        
    }
}
