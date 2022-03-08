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
            
            ((LevelManager) LevelManager.Instance).SetQuest(quest);
            quest = null;
        }
    }
}