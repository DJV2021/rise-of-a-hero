using System;
using UnityEngine;

namespace Game.Quests
{
    [Serializable]
    public class Quest : IGameEventListener
    {
        // the data of the quest
        [SerializeField] private QuestData data;
        public QuestData Data => data;

        private QuestStateHandler _state;
        
        public void StartQuest()
        {
            _state = data.GetStateHandler();
        }

        public void OnEnemyKilled()
        {
            _state.OnEnemyKilled();
        }

        public bool QuestCompleted()
        {
            return _state.QuestCompleted();
        }
    }

    [Serializable]
    public abstract class QuestData : ScriptableObject
    {
        public abstract string GetDisplayName();
        public abstract QuestStateHandler GetStateHandler();
    }

    public abstract class QuestStateHandler : IGameEventListener
    {
        public virtual void OnEnemyKilled() {}
        public abstract bool QuestCompleted();
    }
}