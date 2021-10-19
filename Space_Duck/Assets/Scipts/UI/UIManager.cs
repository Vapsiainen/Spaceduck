using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverGO;

    public void InitializeUI(List<Item> items, float time)
    {
        FindObjectOfType<UI_Collectables>().Init(items);
        FindObjectOfType<UI_Timer>().Init(time);
        FindObjectOfType<UI_EnergyMeter>().Init(100);
    }

    public void ShowGameOver()
    {
        gameOverGO.SetActive(true);        
    }

    public static void UpdateEnergyMeter(int newValue)
    {

    }

    public void UpdateTimer(float time)
    {

    }

    public void CollectItem(Item collectable)
    {

    }
}
