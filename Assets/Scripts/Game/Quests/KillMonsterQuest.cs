using System;

namespace Game.Quests
{
    // Info of the quest
    [Serializable]
    public class KillMonsterQuest : QuestData
    {
        public int numberToKill = 1;

        public override string GetDisplayName()
        {
            return $"Kill {numberToKill} monsters";
        }

        public override QuestStateHandler GetStateHandler()
        {
            return new KillMonsterQuestHandler(this);
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