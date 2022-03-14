using MoreMountains.Tools;

namespace Game.Events
{
    public enum PowerUpEventTypes
    {
        Dash,
        Glide,
        JetPack
        // ...
    }
    
    public struct PowerUpEvent
    {
        public PowerUpEventTypes PowerUpEventType;
        public string Name;

        private static PowerUpEvent _e;

        public static void Trigger(PowerUpEventTypes powerUpEventTypes)
        {
            _e.PowerUpEventType = powerUpEventTypes;
            _e.Name = powerUpEventTypes.ToString();
            
            MMEventManager.TriggerEvent(_e);
        }
    }
}