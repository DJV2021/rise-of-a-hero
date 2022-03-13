using System;
using JetBrains.Annotations;
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

        public bool QuestCompleted()
        {
            return _state.QuestCompleted();
        }

        public override string ToString()
        {
            return data.ToString();
        }
    }

    [Serializable]
    public abstract class QuestData : ScriptableObject
    {
        public abstract string GetDisplayName();
        public abstract QuestStateHandler GetStateHandler();
        [CanBeNull] public abstract QuestRewardData Reward();
        public override string ToString()
        {
            return GetDisplayName();
        }
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
        public virtual void OnEnemyKilled() {}

        public abstract bool QuestCompleted();
    }
}