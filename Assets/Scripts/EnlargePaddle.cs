using UnityEngine;
using System.Collections;

public class EnlargePaddle : MonoBehaviour {

	private Paddle paddle;

	// Use this for initialization
	void Start () {
		Vector2 tweak = new Vector2 (Random.Range(0f, 2f), Random.Range(0f, 5f));
		gameObject.GetComponent<Rigidbody2D> ().velocity = tweak;
		paddle = GameObject.FindObjectOfType<Paddle> ();
	}

	/**
	 * Tiggers on Collision
	 */
	void OnCollisionEnter2D(Collision2D collider)
	{
		
		Vector3 largerPaddleScale = new Vector3 (paddle.transform.localScale.x + 1f, paddle.transform.localScale.y, paddle.transform.localScale.z);
		if (collider.gameObject.name == "Paddle") {
			paddle.transform.localScale = largerPaddleScale;
			Destroy (gameObject);
		}
	}
}
