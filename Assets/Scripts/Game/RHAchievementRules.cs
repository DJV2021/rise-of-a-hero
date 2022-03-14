using System;
using Game.Events;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine;

namespace Game
{
	/// <summary>
	/// This class describes how the Corgi Engine demo achievements are triggered.
	/// It extends the base class MMAchievementRules
	/// It listens for different event types
	/// </summary>
	public class RHAchievementRules : AchievementRules, MMEventListener<EnemyDeathEvent>
	{
		/// <summary>
		/// When we catch an MMGameEvent, we do stuff based on its name
		/// </summary>
		/// <param name="gameEvent">Game event.</param>
		public override void OnMMEvent(MMGameEvent gameEvent)
		{

			base.OnMMEvent(gameEvent);

		}

		private void Start()
		{
			Awake();
		}

		public override void OnMMEvent(MMCharacterEvent characterEvent)
		{
			
		}

		public override void OnMMEvent(CorgiEngineEvent corgiEngineEvent)
		{
			bool newAchTrigger = false;
			switch (corgiEngineEvent.EventType)
			{
				case CorgiEngineEventTypes.GameOver:
					newAchTrigger = true;
					MMAchievementManager.AddProgress("Gameover_1", 1);
					break;				
				case CorgiEngineEventTypes.PlayerDeath:
					newAchTrigger = true;
					AddMultiProgress("Die_");
					break;
			}
			if(newAchTrigger) MMAchievementManager.SaveAchievements();
		}

		public override void OnMMEvent(PickableItemEvent pickableItemEvent)
		{
			base.OnMMEvent(pickableItemEvent);
		}

		public void OnMMEvent(EnemyDeathEvent enemyDeathEvent)
		{
			AddMultiProgress("KillMonsters_");
		}

		public override void PrintCurrentStatus()
		{
			foreach (MMAchievement achievement in AchievementList.Achievements)
			{
				string status = achievement.UnlockedStatus ? "unlocked" : "locked";
				string progressLine = achievement.AchievementType == AchievementTypes.Progress
					? ", progress: " + achievement.ProgressCurrent + "/" + achievement.ProgressTarget
					: "";
				Debug.Log("[" + achievement.AchievementID + "] " + achievement.Title + ", status : " + status +
				          progressLine);
			}	
		}

		private void AddMultiProgress(string idBeginning)
		{
			foreach(var achievement in AchievementList.Achievements)
			{
				if (achievement.AchievementID.StartsWith(idBeginning) && !achievement.UnlockedStatus)
				{
					MMAchievementManager.AddProgress(achievement.AchievementID, 1);
					if (achievement.UnlockedStatus)
					{
						Debug.Log("Got this achievement");
						GPSManager.Instance.GiveWelcome();
					}
				}
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			this.MMEventStartListening<EnemyDeathEvent>();
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			this.MMEventStopListening<EnemyDeathEvent>();
		}
	}
}