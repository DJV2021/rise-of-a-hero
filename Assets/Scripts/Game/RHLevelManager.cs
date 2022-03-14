using MoreMountains.CorgiEngine;

namespace Game
{
    /// <summary>
    /// Extends the default LevelManger.
    /// </summary>
    public class RHLevelManager : MoreMountains.CorgiEngine.LevelManager
    {
        public new static RHLevelManager Instance => (RHLevelManager) LevelManager.Instance;
        
        public static Character GetPlayer => Instance.Players[0];
    }
}