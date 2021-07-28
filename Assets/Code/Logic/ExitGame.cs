using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitGame : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
			#endif

			#if UNITY_STANDALONE
				Application.Quit();
			#endif

			#if UNITY_WEBGL
				SceneManager.LoadScene("1-Main Menu");
			#endif
		}
	}
}
