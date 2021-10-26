using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float levelTime = 5.0f;

    public int energy;
    public int key;
    public bool carryingKey = false;
    public int ducks;

    [SerializeField]
    private float defGravity = 9.14f, changeGravity = 9.14f;
    private UIManager uiManager;
    private bool isPaused, gameOver;

    public bool IsGameOver
    {
        get
        {
            return gameOver;
        }
        set
        {
            gameOver = value;
            IsPaused = gameOver ? true : false;
        }
    }

    public bool IsPaused
{
        get
        {
            return isPaused;
        }
        set
        {
            isPaused = value;

            Time.timeScale = IsPaused ? 0 : 1;
            Cursor.visible = IsPaused;
            Cursor.lockState = IsPaused ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }

    private void Start()
    {
        IsPaused = false;
        Physics.gravity = -Vector3.up * defGravity;

        uiManager = FindObjectOfType<UIManager>();
        uiManager.InitializeUI(FindObjectsOfType<Item>(), levelTime);        
    }

    private void Update()
    {
        if (IsGameOver)
            return;

        levelTime -= Time.deltaTime;

        if (levelTime <= 0)
        {
            uiManager.UpdateTimer(levelTime);
            GameOver("Time ran out...");
        }
        else
            uiManager.UpdateTimer(levelTime);

        if(Input.GetKeyDown("escape"))
        {
            IsPaused = !IsPaused;
            if (IsPaused)
                uiManager.ShowPause();
            else
                uiManager.HidePause();
        }
    }

    public void ChangeGravity(Vector3 dir)
    {
        Physics.gravity = dir * changeGravity;
    }

    public void LockGravity(Vector3 dir)
    {
        Physics.gravity = dir * defGravity;
    }

    public void CollectItem(Item item)
    {
        carryingKey = true;
        uiManager.CollectItem(item);
    }

    public void GameOver(string message)
    {
        uiManager.ShowGameOver(message);
        IsGameOver = true;
    }

    public void Exit()
    {
        if (carryingKey)
        {
            IsGameOver = true;
            uiManager.ShowLevelComplete("Level complete!");
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void CollectDuck(Item item)
    {
        ducks++;
        uiManager.CollectItem(item);
    }

    public Settings settings;
}
