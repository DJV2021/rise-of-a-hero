using Game.Enemies;
using Game.Quests;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UI;

namespace Game
{
    /// <summary>
    /// Extends the default GameManger.
    /// </summary>
    public class RHGameManager : GameManager, IGameEventListener, MMEventListener<EnemyDeathEvent>
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
            OnCurrentQuestChanged(); // clear
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