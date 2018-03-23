using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRacket : MonoBehaviour {
    public float speed = 30;
    public string axis = "Vertical";
    public Rigidbody2D leftRacket;
    public int xToStop;

    public void FixedUpdate() {
        GameObject ball = GameObject.Find("Ball");
        Ball ballClass = ball.GetComponent<Ball>();
        Rigidbody2D invisibleBall = ballClass.invBall;

        GameObject rightRacketObject = GameObject.Find("Racket_right");
        MoveRightRacket moveRight = rightRacketObject.GetComponent<MoveRightRacket>();
        Rigidbody2D right = moveRight.rightRacket;

		if (DataPasser.difficulty == 0) {
			xToStop = -2;
		} else if (DataPasser.difficulty == 1) {
			xToStop = -5;
		} else if (DataPasser.difficulty == 2) {
			xToStop = -8;
		} else {
			xToStop = -11;
		}


        if (DataPasser.multiplayer) {
            float v = Input.GetAxisRaw(axis);
            leftRacket.velocity = new Vector2(0, v) * speed;
        } else {
            if (invisibleBall.transform.position.x >= xToStop && invisibleBall.transform.position.x < right.transform.position.x) {
                if (invisibleBall.transform.position.y > leftRacket.transform.position.y) {
                    leftRacket.velocity = new Vector2(0, 1) * speed;
                } else if (invisibleBall.transform.position.y == leftRacket.transform.position.y) {
                    leftRacket.velocity = new Vector2(0, 0);
                } else {
                    leftRacket.velocity = new Vector2(0, -1) * speed;
                }
            }  else {
                leftRacket.velocity = new Vector2(0, 0);
            }
        }
    }
}
