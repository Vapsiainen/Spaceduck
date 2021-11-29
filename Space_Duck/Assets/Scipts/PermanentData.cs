using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PermanentData : MonoBehaviour
{
    public static PermanentData instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        LoadSettings();
        LoadProgress();
    }

    public Settings settings;
    public GameProgress progress;

    private string SettingsFilePath { get => Application.persistentDataPath + "/settings.txt"; }

    public void SaveSettings()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(SettingsFilePath);
        bf.Serialize(file, settings);
        file.Close();
    }

    public void LoadSettings()
    {
        if (File.Exists(SettingsFilePath))
        {
            Debug.Log(SettingsFilePath);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(SettingsFilePath, FileMode.Open);
            settings = (Settings)bf.Deserialize(file);
            file.Close();
        }
        else
            settings = new Settings();
    }

    private string ProgressFilePath { get => Application.persistentDataPath + "/progress.txt"; }

    public void SaveProgress()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(ProgressFilePath);
        bf.Serialize(file, progress);
        file.Close();
    }

    public void LoadProgress()
    {
        if (File.Exists(ProgressFilePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(ProgressFilePath, FileMode.Open);
            progress = (GameProgress)bf.Deserialize(file);
            file.Close();
        }
        else
            progress = new GameProgress();
    }
}
