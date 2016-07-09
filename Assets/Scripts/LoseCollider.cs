using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;

	public static int lives = 3;

    void OnTriggerEnter2D(Collider2D trigger)
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
		if (lives <= 0) {
			levelManager.LoadLevel ("Lose");
		} else {
			levelManager.ReloadLevel();
			lives--;	
		}
    }
}
