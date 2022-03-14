using MoreMountains.Tools;

namespace Game.Events
{
    public enum RHEventTypes
    {
        BossDeath,
        PlayerDeathFromBoss,
        PlayedForOneSec
    }
    public struct RHEvent
    {
        public RHEventTypes EventType;

        private static RHEvent _e;

        public static void Trigger(RHEventTypes eventType)
        {
            _e.EventType = eventType;
            MMEventManager.TriggerEvent(_e);
        }
        
        // made to be converted to a delegate in BossDeathTracker
        public static void TriggerBossDeath()
        {
            _e.EventType = RHEventTypes.BossDeath;
            MMEventManager.TriggerEvent(_e);
            EnemyDeathEvent.Trigger();
        }
    }
}