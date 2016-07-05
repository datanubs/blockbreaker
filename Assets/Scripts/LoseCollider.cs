using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D trigger)
    {
        SceneManager.LoadScene("Lose");
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collission");
    }
}
