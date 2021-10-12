using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverGO;

    public void InitializeUI(List<ICollectable> collectables, float time)
    {
        FindObjectOfType<GameScene_UI_Collectables>().Init(collectables);
        FindObjectOfType<GameScene_UI_Timer>().Init(time);
        FindObjectOfType<GameScene_UI_EnergyMeter>().Init(100);
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

    public void CollectItem(Collectable collectable)
    {

    }
}
