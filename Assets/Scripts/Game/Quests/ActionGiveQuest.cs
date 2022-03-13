using MoreMountains.CorgiEngine;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Quests
{
    /// <summary>
    /// Give a quest to the player
    /// </summary>
    [RequireComponent(typeof(ButtonActivated))]
    public class ActionGiveQuest : MonoBehaviour
    {
        [FormerlySerializedAs("quest")] [SerializeField] private Quest mainQuest;
        [SerializeField] private Quest nextQuest;

        // the "button" used to trigger the action
        private ButtonActivated _buttonActivated;

        private void Awake()
        {
            _buttonActivated = GetComponent<ButtonActivated>();
            var gameManager = (RHGameManager)GameManager.Instance;

            // if we are doing a quest or we already did the main quest and we don't have any more quests
            if (gameManager.HasQuest() || gameManager.HasDoneMainQuest() && nextQuest == null)
                _buttonActivated.Activable = false;
            else
                _buttonActivated.Activable = true;
        }

        public void SetCurrentQuest()
        {
            var gameManager = (RHGameManager) GameManager.Instance;
            if (gameManager.HasQuest()) // should not occur
            {
                _buttonActivated.Activable = false;
                return;
            }

            // give next quest
            if (gameManager.HasDoneMainQuest())
            {
                if (nextQuest != null)
                    gameManager.SetQuest(nextQuest);
            }
            // give mainQuest
            else
            {
                gameManager.SetQuest(mainQuest);
            }

            _buttonActivated.Activable = false;
        }
    }
}