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
    public Rigidbody2D invBall;
    public static bool invBallMoving = false;
    public Rigidbody2D leftRacket;
	public Rigidbody2D rightRacket;
    int counter = 0;

	// Use this for initialization
	void Start () {
        Debug.Log("Calling Start");
        maxScore = DataPasser.maxScore;

        // Initial Velocity
        speed = DataPasser.initialSpeed;
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        setScoreText();
    }

    private void Update() {
        maxScore = DataPasser.maxScore;

        if (counter <= 100) {
            counter++;
        } else {
            Debug.Log("position: " + GetComponent<Rigidbody2D>().transform.position.y);
            Debug.Log("speed: " + speed);
            counter = 0;
        }

        if (DataPasser.increaseSpeed) {
            int bigger;

            if (scoreLeft > scoreRight) {
                bigger = scoreLeft;
            } else {
                bigger = scoreRight;
            }

            if (bigger >= (maxScore / 4) && bigger < (maxScore / 2)) {
                speed = DataPasser.initialSpeed * 1.3f;
            } else if (bigger >= maxScore / 2 && bigger < (maxScore / 4) * 3) {
                speed = DataPasser.initialSpeed * 1.7f;
            } else if (bigger >= (maxScore / 4) * 3 && bigger < maxScore) {
                speed = DataPasser.initialSpeed * 2.1f;
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
            Debug.Log("hitFactor: " + y);
            // Calculate direction, make length = 1 via normalizing
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set velocity with dir speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;

            if (!DataPasser.multiplayer) {
                invBall.transform.position = GetComponent<Rigidbody2D>().transform.position;
                invBall.velocity = dir * speed * 1.7f;
                invBallMoving = true;
            }
        }

        // Hits the right wall -> point for left player
        if (col.gameObject.name == "WallVertical_right") {
            transform.position = new Vector3(3, -13, 0);
            StartCoroutine(HitRight());
        }

        // Hits the left wall -> point for right player
        if (col.gameObject.name == "WallVertical_left") {
            transform.position = new Vector3(3, -13, 0);
			StartCoroutine(HitLeft());
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

	IEnumerator HitRight() {
		GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
		scoreLeft++;
		setScoreText();
		yield return new WaitForSeconds(1);
		setVelocity(1);

		leftRacket.transform.position = new Vector3(-16, setRandomNumber(), 0);
	}

	IEnumerator HitLeft() {
		GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
		scoreRight++;
		setScoreText();
		yield return new WaitForSeconds(1);
		setVelocity(-1);

		leftRacket.transform.position = new Vector3(-16, setRandomNumber(), 0);
	}

    void setVelocity(int direction) {
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction, 0) * speed;
    }

	float setRandomNumber() {
		// -15, -11.5
		return Random.Range(-15f, -11.5f);
	}
}
