using System;
using MoreMountains.CorgiEngine;
using UnityEngine;

namespace Game.Quests
{
    [Serializable]
    public class Quest
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

        public string GetDisplayName()
        {
            return _state.GetDisplayName();
        }

        public bool QuestCompleted()
        {
            return _state.QuestCompleted();
        }

        public override string ToString()
        {
            return _state.ToString();
        }
    }

    [Serializable]
    public abstract class QuestData : ScriptableObject
    {
        public abstract QuestStateHandler GetStateHandler();

        public abstract QuestRewardData Reward();
    }

    [Serializable]
    public abstract class QuestRewardData : ScriptableObject
    {
        public abstract string GetDisplayName();
        public abstract void Give(Character player);
        public override string ToString()
        {
            return GetDisplayName();
        }
    }

    public abstract class QuestStateHandler
    {
        public abstract string GetDisplayName();

        public virtual void OnEnemyKilled() {}

        public abstract bool QuestCompleted();

        public override string ToString()
        {
            return GetDisplayName();
        }
    }
}