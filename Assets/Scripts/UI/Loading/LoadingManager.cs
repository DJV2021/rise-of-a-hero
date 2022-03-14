using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

namespace UI.Loading
{
	public class LoadingManager : MMSceneLoadingManager, IUnityAdsShowListener
	{
		protected override void Start()
		{
			// no progress bar
			if (!LoadingProgressBar)
			{
				var g =new GameObject();
				LoadingProgressBar = g.AddComponent<CanvasGroup>();
				LoadingProgressBar.gameObject.AddComponent<Image>();
			}
			// no complete animation
			if (!LoadingCompleteAnimation)
			{
				var g = new GameObject();
				LoadingCompleteAnimation = g.AddComponent<CanvasGroup>();
			}
			
			// start
			base.Start();
		}

		protected override void LoadingComplete()
		{
			if (Random.Range(0,20) > 17) Advertisement.Show("Rewarded_Android", this);
			else base.LoadingComplete(); 
		}

		// Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
		public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
		{
			// && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED)
			if (!adUnitId.Equals("Rewarded_Android")) return;
			Debug.Log("Unity Ads Rewarded Ad Completed");
			// Grant a reward.
			base.LoadingComplete();
		}
 
		// Implement Load and Show Listener error callbacks:
		public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
		{
			Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
			// Use the error details to determine whether to try to load another ad.
		}
 
		public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
		{
			Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
			// Use the error details to determine whether to try to load another ad.
		}
 
		public void OnUnityAdsShowStart(string adUnitId) { }
		public void OnUnityAdsShowClick(string adUnitId) { }
	}
}