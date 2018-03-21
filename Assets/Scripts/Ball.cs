using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {
    public float speed = 30;
    public Text scoreText;
    int scoreLeft = 0;
    int scoreRight = 0;

	// Use this for initialization
	void Start () {
        // Initial Velocity
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        setScoreText();
    }

    private void Update() {
        
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

		if (scoreLeft == 10) {
			DataPasser.winner = 1;
			SceneManager.LoadScene("scene_finish");
		} 
        
        if (scoreRight == 10) {
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
