using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// Extends the default GUIManger.
    /// </summary>
    public class GUIManager : MoreMountains.CorgiEngine.GUIManager
    {
        [Header("Quests")]
        [Tooltip("Label to put the display name of the quest")]
        public Text currentQuestLabel;
    }
}