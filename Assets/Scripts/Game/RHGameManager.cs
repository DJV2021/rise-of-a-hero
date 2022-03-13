using Game.Events;
using Game.Quests;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;

namespace Game
{
    /// <summary>
    /// Extends the default GameManger.
    /// </summary>
    public class RHGameManager : GameManager, MMEventListener<EnemyDeathEvent>
    {
        //  we can only have one quest at a time
        public void SetQuest(Quest quest)
        {
            CurrentQuest = quest;
            quest.StartQuest();

            // fire event
            QuestEvent.Trigger(CurrentQuest, QuestMethods.Started);
        }
        
        public Quest CurrentQuest { get; private set; }
        public bool HasQuest() => CurrentQuest != null;

        public void OnEnemyKilled()
        {
            // no quest
            if (CurrentQuest == null) return;
            // fire event
            CurrentQuest.OnEnemyKilled();
            
            // the quest is done
            if (!CurrentQuest.QuestCompleted()) return;
            // Give reward if we got one
            CurrentQuest.Data.Reward()?.Give(LevelManager.Instance.Players[0]);

            // clear
            CurrentQuest = null;

            // fire event with null, completed :D
            QuestEvent.Trigger(CurrentQuest, QuestMethods.Completed);
        }

        // Events

        public virtual void OnMMEvent(EnemyDeathEvent pointEvent)
        {
            OnEnemyKilled();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            this.MMEventStartListening<EnemyDeathEvent> ();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            this.MMEventStopListening<EnemyDeathEvent> ();
        }
    }
}