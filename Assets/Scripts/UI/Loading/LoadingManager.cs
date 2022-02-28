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
			var g =new GameObject();
			LoadingProgressBar = g.AddComponent<CanvasGroup>();
			LoadingProgressBar.gameObject.AddComponent<Image>();
			base.Start();
		}
	}
}