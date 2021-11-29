using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class GameProgress
{
    public List<Level> levels = new List<Level>();

    public GameProgress()
    {
        for (int i = 1; i <= 3; i++)        
            levels.Add(new Level(i));        
    }
}

[Serializable]
public class Level
{
    public bool ducklingCollected;
    public int levelIndex;
    public bool cleared;
    public float time;

    public void Cleared(float newTime)
    {        
        if(newTime > time || !cleared)        
            time = newTime;        

        cleared = true;
    }

    public Level(int index)
    {
        levelIndex = index;
    }
}
