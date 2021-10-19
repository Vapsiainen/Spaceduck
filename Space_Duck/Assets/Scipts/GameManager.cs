using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int energy;
    public int key;
    public bool carryingKey = false;
    public int ducks;

    public Settings settings;
}
