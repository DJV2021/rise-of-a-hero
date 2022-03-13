using UnityEngine;

namespace Game.Quests
{
    [CreateAssetMenu(menuName = "Rise of a hero/Quests/KillMonsterQuest")]
    public class KillMonsterQuest : QuestData
    {
        [SerializeField] private int minInclusive = 1;
        [SerializeField] private int maxInclusive = 1;
        internal int NumberToKill => Random.Range(minInclusive, maxInclusive+1);

        public QuestRewardData reward;

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
        private int _numberKilled;
        private readonly int _numberToKill;

        public KillMonsterQuestHandler(KillMonsterQuest data)
        {
            _numberToKill = data.NumberToKill;
        }

        public override string GetDisplayName()
        {
            return $"Kill {_numberToKill - _numberKilled} monsters";
        }

        public override void OnEnemyKilled()
        {
            base.OnEnemyKilled();
            _numberKilled++;
        }

        public override bool QuestCompleted()
        {
            return _numberKilled >= _numberToKill;
        }
    }
}