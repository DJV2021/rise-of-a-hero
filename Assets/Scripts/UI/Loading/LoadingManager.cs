using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Loading
{
	public class LoadingManager : MMSceneLoadingManager 
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
	}
}