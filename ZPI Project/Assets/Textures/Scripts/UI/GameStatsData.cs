using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatsData {
    static public List<List<bool>> mapsAndFinishedLevels = new List<List<bool>>();

    static public bool levelFinished(int mapNr, int levelNr)
    {
        if (mapNr < mapsAndFinishedLevels.Count && levelNr < mapsAndFinishedLevels[mapNr].Count)
            return mapsAndFinishedLevels[mapNr][levelNr];
        return false;
    }

    static public void finishLevel(int mapNr, int levelNr)
    {
        if (mapNr >= mapsAndFinishedLevels.Count)
        {
            var tmp = new List<bool>();
            tmp.Add(true);
            mapsAndFinishedLevels.Add(tmp);
            
        }
        else if (levelNr >= mapsAndFinishedLevels[mapNr].Count)
        {
            mapsAndFinishedLevels[mapNr].Add(true);
        }
    }
}
