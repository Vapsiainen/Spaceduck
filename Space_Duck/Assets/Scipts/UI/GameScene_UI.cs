using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene_UI : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverGO;

    public void InitializeUI(List<ICollectable> collectables, float time)
    {
        FindObjectOfType<GameScene_UI_Collectables>().Init(collectables);
        FindObjectOfType<GameScene_UI_Timer>().Init(time);
    }

    public void ShowGameOver()
    {
        gameOverGO.SetActive(true);
    }
}
