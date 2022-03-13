using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine;

namespace Game.Enemies
{
    [RequireComponent(typeof(Health))]
    public class EnemyDeathTracker : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<Health>().OnDeath = EnemyDeathEvent.Trigger;
        }
    }

    public struct EnemyDeathEvent
    {
        private static EnemyDeathEvent _e;

        public static void Trigger()
        {
            MMEventManager.TriggerEvent(_e);
        }
    }
}