using UnityEngine;

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
		}
	}
}
