using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

	public void ReloadLevel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

    public void BrickDestroyed()
    {
		//currentLevelIndex = SceneManager.GetActiveScene ().buildIndex;
        if(Brick.breakableCount <= 0)
        {
			//LoadLevel ("Load");
			LoadNextLevel ();
        }
		
    }
}
