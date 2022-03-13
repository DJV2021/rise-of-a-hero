using MoreMountains.Tools;

namespace Game.Events
{
    /// <summary>
    /// Event triggered when an enemy was killed
    /// </summary>
    public struct EnemyDeathEvent
    {
        private static EnemyDeathEvent _e;

        public static void Trigger()
        {
            MMEventManager.TriggerEvent(_e);
        }
    }
}