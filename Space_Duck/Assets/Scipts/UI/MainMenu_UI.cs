using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_UI : MonoBehaviour
{
    [SerializeField]
    private UI_Settings settingsPanel;

    public void ButtonClick_StartGame(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ButtonClick_ShowSettings()
    {
        settingsPanel.gameObject.SetActive(true);
        settingsPanel.Init();
    }
}
