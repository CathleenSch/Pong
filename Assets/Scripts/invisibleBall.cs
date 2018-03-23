using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisibleBall : MonoBehaviour {
    public Rigidbody2D invBall;
    public int xToStop = DataPasser.difficulty;

	void FixedUpdate () {
		if (DataPasser.difficulty == 0) {
			xToStop = -2;
		} else if (DataPasser.difficulty == 1) {
			xToStop = -5;
		} else if (DataPasser.difficulty == 2) {
			xToStop = -8;
		} else {
			xToStop = -11;
		}

        if (!DataPasser.multiplayer && Ball.invBallMoving && invBall.transform.position.x <= xToStop) {
            invBall.velocity = new Vector2(0, 0);
            Ball.invBallMoving = false;
            invBall.transform.position = new Vector3(32, -14, 0);
        }
	}
}
