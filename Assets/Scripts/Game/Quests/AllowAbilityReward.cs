using Game.Events;
using MoreMountains.CorgiEngine;
using UnityEngine;

namespace Game.Quests
{
    /**
     * Allow an ability to be used.
     */
    [CreateAssetMenu(menuName = "Rise of a hero/Reward/AllowAbility")]
    public class AllowAbilityReward : QuestRewardData
    {
        [SerializeField] private CharacterAbility ability;
        [SerializeField] private string displayName;
        [SerializeField] private PowerUpEventTypes eventType;
        [SerializeField] private string eventName;

        public override string GetDisplayName()
        {
            return $"Skill [{displayName}]";
        }

        public override void Give(Character player)
        {
            // get the script on the instance of the player, do not edit the prefab
            var component = player.GetComponent(ability.GetType()) as CharacterAbility;
            if (component == null) return;
            PowerUpEvent.Trigger(eventType, eventName);
            component.PermitAbility(true);
        }
    }
}