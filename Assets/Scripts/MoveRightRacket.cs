using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightRacket : MonoBehaviour {
    public float speed = 30;
    public string axis = "Vertical";
    public Rigidbody2D rightRacket;

    private void FixedUpdate() {
        float v = Input.GetAxisRaw(axis);
        rightRacket.velocity = new Vector2(0, v) * speed;

    }
}
