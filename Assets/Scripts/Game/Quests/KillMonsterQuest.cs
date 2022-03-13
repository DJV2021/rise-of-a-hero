using UnityEngine;

namespace Game.Quests
{
    [CreateAssetMenu(menuName = "Rise of a hero/Quests/KillMonsterQuest")]
    public class KillMonsterQuest : QuestData
    {
        public int numberToKill = 1;
        public QuestRewardData reward;

        public override string GetDisplayName()
        {
            return $"Kill {numberToKill} monsters";
        }

        public override QuestStateHandler GetStateHandler()
        {
            return new KillMonsterQuestHandler(this);
        }

        public override QuestRewardData Reward()
        {
            return reward;
        }
    }
    
    // Handler of the progress of the quest
    public class KillMonsterQuestHandler : QuestStateHandler
    {
        private readonly KillMonsterQuest _data;
        private int _numberKilled;

        public KillMonsterQuestHandler(KillMonsterQuest data)
        {
            _data = data;
        }

        public override void OnEnemyKilled()
        {
            base.OnEnemyKilled();
            _numberKilled++;
        }

        public override bool QuestCompleted()
        {
            return _data.numberToKill <= _numberKilled;
        }
    }
}