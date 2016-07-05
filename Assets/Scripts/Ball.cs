using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    public Paddle paddle;
    bool shouldStick = true;
    private Vector3 paddleToBallVector;
	// Use this for initialization
	void Start () {
        paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (shouldStick)
        {
            this.transform.position = paddle.transform.position + paddleToBallVector;



            if (Input.GetMouseButtonDown(0))
            {
                shouldStick = false;
                GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            }
        }
	}
}
