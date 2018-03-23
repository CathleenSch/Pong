using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {
    public float speed;
    public Text scoreText;
    int scoreLeft = 0;
    int scoreRight = 0;
    int maxScore;

	// Use this for initialization
	void Start () {
        maxScore = DataPasser.maxScore;

        // Initial Velocity
        speed = DataPasser.initialSpeed;
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        setScoreText();
    }

    private void Update() {
        maxScore = DataPasser.maxScore;

        if (DataPasser.increaseSpeed) {
            if ((scoreLeft >= maxScore / 4 && scoreLeft < maxScore / 2) || (scoreRight >= maxScore / 4 && scoreRight < maxScore / 2)) {
                speed = DataPasser.initialSpeed * 1.5f;
            } else if ((scoreLeft >= maxScore / 2 && scoreLeft < (maxScore / 4) * 3) || (scoreRight >= maxScore / 2 && scoreRight < (maxScore / 4) * 3)) {
                speed = DataPasser.initialSpeed * 2.0f;
            } else if ((scoreLeft >= (maxScore / 4) * 3 && scoreLeft < maxScore) || (scoreRight >= (maxScore / 4) * 3 && scoreRight < maxScore)) {
                speed = DataPasser.initialSpeed * 2.5f;
            } else {
                speed = DataPasser.initialSpeed;
            }
        } else {
            speed = DataPasser.initialSpeed;
        }
    }


    private void OnCollisionEnter2D(Collision2D col) {
        // Hit left racket?
        if (col.gameObject.name == "Racket_left") {
            // Calculate hit factor
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            // Calculate direction, make length = 1 via normalizing
            Vector2 dir = new Vector2(1, y).normalized;

            // Set velocity with dir speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        // Hit right racket?
        if (col.gameObject.name == "Racket_right")
        {
            // Calculate hit factor
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            // Calculate direction, make length = 1 via normalizing
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set velocity with dir speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        // Hits the right wall -> point for left player
        if (col.gameObject.name == "WallVertical_right") {
            transform.position = new Vector3(3, -13, 0);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            scoreLeft++;
            setScoreText();
            StartCoroutine(Wait());
            setVelocity(1);
        }

        // Hits the left wall -> point for right player
        if (col.gameObject.name == "WallVertical_left") {
            transform.position = new Vector3(3, -13, 0);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            scoreRight++;
            setScoreText();
            StartCoroutine(Wait());
            setVelocity(-1);
        }
    }

    float hitFactor (Vector2 ballPos, Vector2 racketPos, float racketHeight) {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void setScoreText() {
        scoreText.text = "Score: \t\t " + scoreLeft.ToString() + ":" + scoreRight.ToString();

		if (scoreLeft == DataPasser.maxScore) {
			DataPasser.winner = 1;
			SceneManager.LoadScene("scene_finish");
		} 
        
        if (scoreRight == DataPasser.maxScore) {
			DataPasser.winner = 2;
            SceneManager.LoadScene("scene_finish");
        }
    }

	IEnumerator Wait() {
		// print(Time.time);
		yield return new WaitForSeconds(50000000);
		// print(Time.time);
	}

    void setVelocity(int direction) {
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction, 0) * speed;
    }
}
