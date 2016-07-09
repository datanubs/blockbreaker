using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool useMouse = true;
	private Ball ball;
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if (useMouse) {
			MoveWithMouse ();
		} else {
			AutoPlay ();
		}
	}

	void AutoPlay() {
		Vector3 paddlePos = new Vector3(ball.transform.position.x, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x-1f, 0f, 14f);
		this.transform.position = paddlePos;
	}

	void MoveWithMouse() {
		float mousePosInBlocks = ((Input.mousePosition.x / Screen.width) * 16);
		Vector3 paddlePos = new Vector3(mousePosInBlocks, this.transform.position.y, 0f);
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0f, 14f);
		this.transform.position = paddlePos; 
	}
}
