using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public float speed = 30;

	// Use this for initialization
	void Start () {
        // Initial Velocity
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
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
    }

    float hitFactor (Vector2 ballPos, Vector2 racketPos, float racketHeight) {
        return (ballPos.y - racketPos.y) / racketHeight;
    }
}
