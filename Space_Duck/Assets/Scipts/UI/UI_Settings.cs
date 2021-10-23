using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Settings : MonoBehaviour
{
    [SerializeField]
    private Toggle soundsToggle, musicToggle, invertMouseToggle;
    [SerializeField]
    private Slider soundSlider, musicSlider;

    public void Init()
    {
        PermanentData.instance.LoadSettings();
        UpdateUI();
    }

    private void UpdateUI()
    {
        soundsToggle.isOn = PermanentData.instance.settings.soundsOn;
        musicToggle.isOn = PermanentData.instance.settings.musicOn;
        invertMouseToggle.isOn = PermanentData.instance.settings.invertMouse;

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

    public void Toggle_MouseInvertion()
    {
        PermanentData.instance.settings.invertMouse = invertMouseToggle.isOn;
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
}
