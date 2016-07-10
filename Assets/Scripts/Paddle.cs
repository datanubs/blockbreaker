using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool useMouse = true;
	private Ball ball;
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		print (gameObject.transform.localScale.x);
	}
	
	// Update is called once per frame
	void Update () {
		if (useMouse) {
			MoveWithMouse ();
		} else {
			AutoPlay ();
		}
	}


	/**
	 * TODO These functions are similar and should be refactored into one function
	 * with the correct position being passed to it goef for AutoPlay() and MoveWithMouse()
	 * */
	void AutoPlay() {
		Vector3 paddlePos = new Vector3(ball.transform.position.x, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x-1f, 0f, 14f);

		this.transform.position = paddlePos;
	}

	void MoveWithMouse() {
		
		float paddleScaleX = gameObject.transform.localScale.x;
		float mousePosInBlocks = ((Input.mousePosition.x / Screen.width) * 16);
		Vector3 paddlePos = new Vector3(mousePosInBlocks, this.transform.position.y, 0f);
		//Make sure that the paddle cannot move outside the play are when changing its scaling
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0f, 16f-paddleScaleX);

		this.transform.position = paddlePos; 
	}
}
