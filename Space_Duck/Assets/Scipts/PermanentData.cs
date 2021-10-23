using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PermanentData : MonoBehaviour
{
    public static PermanentData instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        Debug.Log(instance);
    }

    public Settings settings;

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
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(SettingsFilePath, FileMode.Open);
            settings = (Settings)bf.Deserialize(file);
            file.Close();
        }
        else
            settings = new Settings();
        Debug.Log(settings);
    }
}
