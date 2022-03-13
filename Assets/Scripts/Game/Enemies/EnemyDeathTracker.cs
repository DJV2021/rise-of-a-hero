using Game.Events;
using MoreMountains.CorgiEngine;
using UnityEngine;

namespace Game.Enemies
{
    [RequireComponent(typeof(Health))]
    public class EnemyDeathTracker : MonoBehaviour
    {
        private void Awake()
        {
            // every enemy tracked will trigger this event
            GetComponent<Health>().OnDeath = EnemyDeathEvent.Trigger;
        }
    }
}