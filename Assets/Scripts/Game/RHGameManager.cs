using Game.Quests;
using MoreMountains.CorgiEngine;
using UI;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Extends the default GameManger.
    /// </summary>
    public class RHGameManager : GameManager, IGameEventListener
    {
        //  we can only have one quest at a time
        public void SetQuest(Quest quest)
        {
            CurrentQuest = quest;
            quest.StartQuest();
            OnCurrentQuestChanged();
        }
        
        public Quest CurrentQuest { get; private set; }

        private static void OnCurrentQuestChanged()
        {
            ((RHGUIManager)GUIManager.Instance).RefreshQuest();
        }

        public void OnEnemyKilled()
        {
            Debug.Log("todo: remove this log in LevelManager#OnEnemyKilled." +
                      " This means that you called this method. Thanks!");
            CurrentQuest.OnEnemyKilled();
            
            // the quest is done
            if (!CurrentQuest.QuestCompleted()) return;
            CurrentQuest = null;
            OnCurrentQuestChanged(); // empty
        }
    }
}