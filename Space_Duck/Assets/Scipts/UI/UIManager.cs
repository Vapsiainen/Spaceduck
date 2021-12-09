using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverGO, pauseGO, levelCompleteGO;
    [SerializeField]
    private TextMeshProUGUI gameOverText, levelCompleteText;

    public void InitializeUI(Item[] items, float time)
    {
        FindObjectOfType<UI_Collectables>().Init(items);
        FindObjectOfType<UI_Timer>().Init(time);
    }

    public void ShowGameOver(string message)
    {
        gameOverGO.SetActive(true);
        gameOverText.text = message;
    }

    public void ShowLevelComplete(string message)
    {
        levelCompleteGO.SetActive(true);
        levelCompleteText.text = message;
    }

    public void ShowPause()
    {
        pauseGO.SetActive(true);        
    }

    public void HidePause()
    {
        pauseGO.SetActive(false);
        if(FindObjectOfType<GameManager>().IsPaused)
            FindObjectOfType<GameManager>().IsPaused = false;
    }

    public static void UpdateEnergyMeter(int newValue)
    {

    }

    public void UpdateTimer(float time)
    {
        FindObjectOfType<UI_Timer>().UpdateTime(time);
    }

    public void CollectItem(Item collectable)
    {
        FindObjectOfType<UI_Collectables>().CollectItem(collectable);
    }
}
