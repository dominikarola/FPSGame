using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelInfo : ButtonInfo
{
    public string levelName;

    public int startMoney;

    public bool finished = false;
}
