using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisibleBall : MonoBehaviour {
    public Rigidbody2D invBall;

	void FixedUpdate () {
		if (Ball.invBallMoving && invBall.transform.position.x == 0) {
            Ball.invBallMoving = false;
        }
	}
}
