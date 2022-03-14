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
	public class RHAchievementRules : AchievementRules, MMEventListener<EnemyDeathEvent>, 
		MMEventListener<QuestEvent>, MMEventListener<RHEvent>, MMEventListener<PowerUpEvent>
	{
		/// <summary>
		/// When we catch an MMGameEvent, we do stuff based on its name
		/// </summary>
		/// <param name="gameEvent">Game event.</param>
		public override void OnMMEvent(MMGameEvent gameEvent)
		{

			base.OnMMEvent(gameEvent);

		}

		public override void OnMMEvent(MMCharacterEvent characterEvent)
		{
			base.OnMMEvent(characterEvent);
		}

		public override void OnMMEvent(CorgiEngineEvent corgiEngineEvent)
		{
			switch (corgiEngineEvent.EventType)
			{
				case CorgiEngineEventTypes.GameOver:
					AddMultiProgress("GameOver_");
					break;				
				case CorgiEngineEventTypes.PlayerDeath:
					AddMultiProgress("Die_");
					break;
			}
			MMAchievementManager.SaveAchievements();
		}

		public override void OnMMEvent(PickableItemEvent pickableItemEvent)
		{
			base.OnMMEvent(pickableItemEvent);
		}

		public void OnMMEvent(EnemyDeathEvent enemyDeathEvent)
		{
			AddMultiProgress("KillMonsters_");
			MMAchievementManager.SaveAchievements();
		}

		public void OnMMEvent(QuestEvent questEvent)
		{
			if (questEvent.Method != QuestMethods.Completed) return;
			AddMultiProgress("FinishQuests_");
			MMAchievementManager.SaveAchievements();
		}
		
		public void OnMMEvent(RHEvent rhEvent)
		{
			switch (rhEvent.EventType)
			{
				case RHEventTypes.BossDeath:
					AddMultiProgress("WinToBoss_");
					break;
				case RHEventTypes.PlayerDeathFromBoss:
					// TODO: assign the trigger
					AddMultiProgress("DieFromBoss_");
					break;
				case RHEventTypes.PlayedForOneSec:
					// TODO: assign the trigger
					AddMultiProgress("TimePlayed_");
					break;
			}
			MMAchievementManager.SaveAchievements();
		}
		
		public void OnMMEvent(PowerUpEvent eventType)
		{
			switch (eventType.PowerUpEventType)
			{
				case PowerUpEventTypes.Dash:
					MMAchievementManager.UnlockAchievement("UnlockPower_"+eventType.Name);
					break;
				case PowerUpEventTypes.Glide:
					// TODO: add this to the game as reward
					break;
				case PowerUpEventTypes.JetPack:
					// TODO: add this to the game as reward
					break;
			}
			MMAchievementManager.SaveAchievements();
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

		private void AddMultiProgress(string idBeginning, int newProgress = 1)
		{
			foreach(var achievement in AchievementList.Achievements)
			{
				if (achievement.AchievementID.StartsWith(idBeginning) && !achievement.UnlockedStatus)
					MMAchievementManager.AddProgress(achievement.AchievementID, newProgress);
			}
		}

		protected override void OnEnable()
		{
			Debug.Log("rhachievement onenable");
			base.OnEnable();
			this.MMEventStartListening<EnemyDeathEvent>();
			this.MMEventStartListening<QuestEvent>();
			this.MMEventStartListening<RHEvent>();
			this.MMEventStartListening<PowerUpEvent>();
		}

		protected override void OnDisable()
		{
			Debug.Log("rhachievement ondisable");
			base.OnDisable();
			this.MMEventStopListening<EnemyDeathEvent>();
			this.MMEventStopListening<QuestEvent>();
			this.MMEventStopListening<RHEvent>();
			this.MMEventStopListening<PowerUpEvent>();
		}
	}
}