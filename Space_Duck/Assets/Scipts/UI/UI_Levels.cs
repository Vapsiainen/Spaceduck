using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Levels : MonoBehaviour
{
    public List<UI_Level> uiLevels;

    private void Start()
    {
        List<Level> levels = FindObjectOfType<PermanentData>().progress.levels;
        for (int i = 0; i < levels.Count; i++)        
            uiLevels[i].Show(i == 0 || levels[i - 1].cleared, levels[i].time, levels[i].ducklingCollected);        
    }
}
