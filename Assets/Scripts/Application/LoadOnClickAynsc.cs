using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadOnClickAynsc : MonoBehaviour {

	public Slider loadingBar;
	public GameObject loadingImage;
	private AsyncOperation async;

	public void ClickAsync(int level)
	{
		loadingImage.SetActive(true);
		StartCoroutine(LoadLevel(level));
		// use for when clicking the home or learn button in game (pause manu Time.timeScale = 0;)
		Time.timeScale = 1;
	}


	IEnumerator LoadLevel(int level)
	{
		async = Application.LoadLevelAsync(level);
		while(!async.isDone)
		{
			loadingBar.value = async.progress;
			yield return null;
		}
	}

}
