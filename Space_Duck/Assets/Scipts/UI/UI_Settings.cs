using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Settings : MonoBehaviour
{
    [SerializeField]
    private Toggle soundsToggle, musicToggle, invertMouseYToggle, invertMouseXToggle;
    [SerializeField]
    private Slider soundSlider, musicSlider, movementSpeedSlider, rotationSpeedSlider;

    public void Init()
    {
        PermanentData.instance.LoadSettings();
        UpdateUI();
    }

    private void UpdateUI()
    {
        soundsToggle.isOn = PermanentData.instance.settings.soundsOn;
        musicToggle.isOn = PermanentData.instance.settings.musicOn;
        invertMouseYToggle.isOn = PermanentData.instance.settings.invertMouseY;
        invertMouseXToggle.isOn = PermanentData.instance.settings.invertMouseX;
        movementSpeedSlider.value = PermanentData.instance.settings.duckMovementSpeed;
        rotationSpeedSlider.value = PermanentData.instance.settings.duckRotationSpeed;

        if (soundsToggle.isOn)
        {
            soundSlider.gameObject.SetActive(true);
            soundSlider.value = PermanentData.instance.settings.soundsVolume;
        }
        else
            soundSlider.gameObject.SetActive(false);

        if (musicToggle.isOn)
        {
            musicSlider.gameObject.SetActive(true);
            musicSlider.value = PermanentData.instance.settings.musicVolume;
        }
        else
            musicSlider.gameObject.SetActive(false);

        PermanentData.instance.SaveSettings();
    }

    public void ButtonClick_Close()
    {
        gameObject.SetActive(false);
    }

    public void Toggle_Sounds()
    {
        PermanentData.instance.settings.soundsOn = soundsToggle.isOn;
        UpdateUI();
    }

    public void Toggle_Music()
    {
        PermanentData.instance.settings.musicOn = musicToggle.isOn;
        UpdateUI();
    }

    public void Toggle_MouseInvertionY()
    {
        PermanentData.instance.settings.invertMouseY = invertMouseYToggle.isOn;        
        UpdateUI();
    }

    public void Toggle_MouseInvertionX()
    {
        PermanentData.instance.settings.invertMouseX = invertMouseXToggle.isOn;
        UpdateUI();
    }

    public void Slide_MusicVolume()
    {
        PermanentData.instance.settings.musicVolume = musicSlider.value;
        UpdateUI();
    }

    public void Slide_SoundVolume()
    {
        PermanentData.instance.settings.soundsVolume = soundSlider.value;
        UpdateUI();
    }

    public void Slide_RotationSpeed()
    {
        PermanentData.instance.settings.duckRotationSpeed = rotationSpeedSlider.value;
        UpdateUI();
    }

    public void Slide_MovementSpeed()
    {
        PermanentData.instance.settings.duckMovementSpeed = movementSpeedSlider.value;
        UpdateUI();
    }
}
