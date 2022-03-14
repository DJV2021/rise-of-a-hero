using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using Game;
using System;
using MoreMountains.Tools;

public class RHStartScreen : StartScreen, MMEventListener<MMSceneLoadingManager.LoadingSceneEvent>
{

    /// <summary>
    /// What happens when the main button is pressed
    /// </summary>
    public override void ButtonPressed()
    {
        MMFadeInEvent.Trigger(FadeOutDuration, Tween, 0, true);
        // if the user presses the "Jump" button, we start the first level.
        StartCoroutine (LoadGameSave());
    }

    private bool BeforeExitFade = false;
    /// <summary>
    /// Loads the Saved game.
    /// </summary>
    protected virtual IEnumerator LoadGameSave()
    {
    
        SaveInfo saveInfo = (SaveInfo)MMSaveLoadManager.Load(typeof(SaveInfo), SaveManager.defaultFileName);
        if (saveInfo != null)
        {
            NextLevel = saveInfo.currentScene;
            RHGameManager.Instance.StoreSelectedCharacter(saveInfo.player);
            RHGameManager.Instance.CurrentLives = saveInfo.CurrentLives;
            RHGameManager.Instance.MaximumLives = saveInfo.MaximumLives;
            RHGameManager.Instance.SetPoints(saveInfo.Points);
            RHGameManager.Instance.LevelMapPosition = saveInfo.LevelMapPosition;
            
        }
        yield return new WaitForSeconds (FadeOutDuration);
        MMSceneLoadingManager.LoadScene (NextLevel);

        yield return new WaitUntil( () =>  BeforeExitFade);

        BeforeExitFade = false;
        //RHGameManager.Instance.LoadQuest(saveInfo.HasDoneMainQuest, saveInfo.CurrentQuest);
    
    }
    public void OnMMEvent(MMSceneLoadingManager.LoadingSceneEvent e)
    {
 	    if (e.Status == MMSceneLoadingManager.LoadingStatus.BeforeExitFade)
	    {
		    BeforeExitFade = true;
	    }
    }
}
