using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Util
{
	public class SceneLoader : MonoBehaviour
	{
		public float loadProgress => _loadProgress;
		protected float _loadProgress;

		public void LoadScene(SceneAsset scene)
		{
			StartCoroutine(LoadSceneAsync(scene));
		}

		// Update is called once per frame
		public IEnumerator LoadSceneAsync(SceneAsset scene)
		{
			AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene.name);

			while (!asyncLoad.isDone)
			{
				_loadProgress = Mathf.Clamp01(asyncLoad.progress / 0.9f);

				yield return null;
			}
		}
	}
}
