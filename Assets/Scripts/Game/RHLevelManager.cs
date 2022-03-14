using MoreMountains.CorgiEngine;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Extends the default LevelManger.
    /// </summary>
    public class RHLevelManager : MoreMountains.CorgiEngine.LevelManager
    {
        public new static RHLevelManager Instance => (RHLevelManager) LevelManager.Instance;
        
        public static Character GetPlayer => Instance.Players[0];

        protected override void RegularSpawnSingleCharacter()
        {
            base.RegularSpawnSingleCharacter();
            if (RHGameManager.Instance.HasDoneMainQuest())
                GetPlayer.GetComponent<CharacterDash>().PermitAbility(true);
        }

        protected override void Cleanup()
        {
            base.Cleanup();

            RHGameManager.Instance.ResetQuest();
        }
    }
}