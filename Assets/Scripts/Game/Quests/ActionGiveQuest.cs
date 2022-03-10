using MoreMountains.CorgiEngine;
using UnityEngine;

namespace Game.Quests
{
    /// <summary>
    /// Give a quest to the player
    /// </summary>
    public class ActionGiveQuest : MonoBehaviour
    {
        [SerializeField] private Quest quest;

        public void SetCurrentQuest()
        {
            // already given
            if (quest == null) return;
            
            ((RHGameManager) GameManager.Instance).SetQuest(quest);
            quest = null;
        }
    }
}