using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
	// Start is called before the first frame update
	public float loadTransition;
	public Animator animFace;
	public string playScene;
	public string creditsScene;
	public string mainMenuScene;

	public void LoadJugarScene()
	{
		SceneManager.LoadScene(playScene);
	}

	public void LoadCredits()
	{
		SceneManager.LoadScene(creditsScene);
	}

	public void LoadMainMenu()
	{
		SceneManager.LoadScene(mainMenuScene);
	}

	public void LoadTheScene(string sceneName)
	{
		IEnumerator Load()
		{
			animFace.SetTrigger("end");
			yield return new WaitForSeconds(loadTransition);
			SceneManager.LoadScene(sceneName);
		}
		StartCoroutine(Load());
	}
}
