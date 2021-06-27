using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animFace;
    public string scene;
    public void LoadJugarScene()
	{
        SceneManager.LoadScene("Game");
	}
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void LoadTheScene()
    {
        
        IEnumerator Load()
        {
            animFace.SetTrigger("end");
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(scene);
                
        }
        StartCoroutine(Load());       
    }
}
