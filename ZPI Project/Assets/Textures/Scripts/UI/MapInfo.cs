using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapInfo : ButtonInfo
{
    public string mapName;
    public List<LevelInfo> levels;

    public bool allLevelsFinished()
    {
        int finished = 0;
        foreach (LevelInfo info in levels)
        {
            if (info.finished)
            {
                finished++;
            }
            else
            {
                break;
            }
        }
        return finished == levels.Count;
    }
}
