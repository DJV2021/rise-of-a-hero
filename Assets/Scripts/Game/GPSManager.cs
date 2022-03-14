using MoreMountains.Tools;
using UnityEngine;

namespace Game
{
    public class GPSManager : MMPersistentSingleton<GPSManager>
    {
        // Start is called before the first frame update
        public void Start()
        {
            GooglePlayGames.PlayGamesPlatform.Activate();
        
            if (!Social.localUser.authenticated) 
                Social.localUser.Authenticate(success => { });
        }

        public void ShowAchievements()
        {
            Social.ShowAchievementsUI();
        }
    }
}
