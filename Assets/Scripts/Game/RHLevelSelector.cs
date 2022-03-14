using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;
using Game;

public class RHLevelSelector : LevelSelector
{
    /// <summary>
    /// Loads the level specified in the inspector
    /// </summary>
    public override void GoToLevel()
    {
        SaveManager.Instance.Save();
        LevelManager.Instance.GotoLevel(LevelName, Fade, Save);
    }
}
