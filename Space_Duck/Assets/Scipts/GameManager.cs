using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public float levelTime = 5.0f;

    public int energy;
    public int key;
    public bool carryingKey = false;
    public int ducks;

    [SerializeField]
    private float defGravity = 9.14f, changeGravity = 9.14f;
    [SerializeField]
    private List<AudioSource> musicSources = new List<AudioSource>();
    [SerializeField]
    List<AudioSource> effectSources = new List<AudioSource>();
    private UIManager uiManager;
    private bool isPaused, gameOver;
    private PlayerControl player;
    private CameraControl cameraControl;
    private GameProgress progress;

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
        player = FindObjectOfType<PlayerControl>();
        cameraControl = FindObjectOfType<CameraControl>();       
        LoadFromSettings();

        IsPaused = false;
        Physics.gravity = -Vector3.up * defGravity;

        uiManager = FindObjectOfType<UIManager>();
        uiManager.InitializeUI(FindObjectsOfType<Item>(), levelTime);        
    }

    private void LoadFromSettings()
    {
        PermanentData permanentData = FindObjectOfType<PermanentData>();
        if (permanentData != null)
        {
            foreach (AudioSource musicSource in musicSources)
            {
                if (permanentData.settings.musicOn)
                    musicSource.volume = permanentData.settings.musicVolume;
                else
                    musicSource.volume = 0;
            }

            foreach (AudioSource effectSource in effectSources)
            {
                if (permanentData.settings.soundsOn)
                    effectSource.volume = permanentData.settings.soundsVolume;
                else
                    effectSource.volume = 0;
            }
            if(player != null)
            {
                player.speed = permanentData.settings.duckMovementSpeed;
                player.turn = permanentData.settings.duckRotationSpeed;
            }
            if(cameraControl != null)
            {
                cameraControl.rotationDirY = permanentData.settings.invertMouseY ? -1 : 1;
                cameraControl.rotationDirX = permanentData.settings.invertMouseX ? -1 : 1;
            }
        }
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
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        IsGameOver = true;
    }

    public void Exit()
    {
        if (carryingKey)
        {
            IsGameOver = true;

            PermanentData permanentData = FindObjectOfType<PermanentData>();
            Level currentLevel = permanentData.progress.levels.FirstOrDefault(x => x.levelIndex == SceneManager.GetActiveScene().buildIndex);
            currentLevel.ducklingCollected = ducks > 0;
            currentLevel.Cleared(levelTime);
            permanentData.SaveProgress();

            uiManager.ShowLevelComplete("Level complete!");
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CollectDuck(Item item)
    {
        ducks++;
        uiManager.CollectItem(item);
    }

    public Settings settings;
}
