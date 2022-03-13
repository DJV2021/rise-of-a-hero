using MoreMountains.CorgiEngine;
using UnityEngine;

namespace Game.Quests
{
    /// <summary>
    /// Give a quest to the player
    /// </summary>
    [RequireComponent(typeof(ButtonActivated))]
    public class ActionGiveQuest : MonoBehaviour
    {
        [SerializeField] private Quest quest;
        
        // the "button" used to trigger the action
        private ButtonActivated _buttonActivated;

        private void Awake()
        {
            _buttonActivated = GetComponent<ButtonActivated>();
            _buttonActivated.Activable = !((RHGameManager)GameManager.Instance).HasQuest();
        }

        public void SetCurrentQuest()
        {
            // todo: not working once reloaded
            if (quest == null) return;
            ((RHGameManager) GameManager.Instance).SetQuest(quest);
            _buttonActivated.Activable = false;
        }
    }
}