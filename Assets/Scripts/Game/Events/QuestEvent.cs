using Game.Quests;
using MoreMountains.Tools;

namespace Game.Events
{
    public enum QuestMethods
    {
        Started,
        Updated,
        Completed
    }
    
    public struct QuestEvent
    {
        public QuestMethods Method;
        public Quest Quest;

        private static QuestEvent _e;
        public static void Trigger(Quest quest, QuestMethods method)
        {
            _e.Quest = quest;
            _e.Method = method;
            MMEventManager.TriggerEvent(_e);
        }

        public override string ToString()
        {
            return Method + " " + Quest;
        }
    }
}