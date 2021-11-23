using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Settings
{
    public bool soundsOn = true;
    public bool musicOn = true;

    public bool invertMouseY = false;
    public bool invertMouseX = false;

    public float soundsVolume = 100;
    public float musicVolume = 100;

    public float duckMovementSpeed = 3;
    public float duckRotationSpeed = 100;
}
