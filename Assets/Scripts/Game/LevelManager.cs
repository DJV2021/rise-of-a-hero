using Game.Quests;
using UI;
using UnityEngine;

namespace Game
{
    public class LevelManager : MoreMountains.CorgiEngine.LevelManager, IGameEventListener
    {
        // can only have one quest at a time
        private Quest _currentQuest;

        public void SetQuest(Quest quest)
        {
            _currentQuest = quest;
            quest.StartQuest();
            SetQuestLabel(quest.Data.GetDisplayName());
        }

        private static void SetQuestLabel(string text)
        {
            ((GUIManager)GUIManager.Instance).currentQuestLabel.text = text;
        }

        public void OnEnemyKilled()
        {
            Debug.Log("todo: remove this log in LevelManager#OnEnemyKilled." +
                      " This means that you called this method. Thanks!");
            _currentQuest.OnEnemyKilled();
            
            // the quest is done
            if (!_currentQuest.QuestCompleted()) return;
            _currentQuest = null;
            SetQuestLabel(""); // empty
        }
    }
}