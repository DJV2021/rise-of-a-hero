using Game;
using Game.Events;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// Extends the default GUIManger.
    /// </summary>
    public class RHGUIManager : GUIManager, MMEventListener<QuestEvent>
    {
        [Header("Quests")]
        [Tooltip("Label to put the display name of the quest")]
        [SerializeField] private Text currentQuestLabel;
        [SerializeField] private Text currentQuestRewardLabel;

        protected override void Awake()
        {
            base.Awake();
            RefreshQuest();
        }

        private void RefreshQuest()
        {
            if (currentQuestLabel == null) return;
            var gameManager = RHGameManager.Current;
            var quest = gameManager == null ? null : gameManager.CurrentQuest;
            currentQuestLabel.text = quest != null ? quest.GetDisplayName() : "";
            var reward = quest?.Data.Reward();
            currentQuestRewardLabel.text = reward != null ? reward.GetDisplayName() : "";
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            this.MMEventStartListening<QuestEvent> ();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            this.MMEventStopListening<QuestEvent> ();
        }

        public void OnMMEvent(QuestEvent eventType)
        {
            // todo: should use event right?
            RefreshQuest();
            
            Debug.Log(eventType);
        }
    }
}