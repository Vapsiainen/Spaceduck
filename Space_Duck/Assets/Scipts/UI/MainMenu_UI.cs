using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_UI : MonoBehaviour
{
    private Camera camera;

    private void Start()
    {
        camera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        camera.transform.RotateAroundLocal(Vector3.up, Time.deltaTime * 0.025f);
    }

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
