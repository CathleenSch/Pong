using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRacket : MonoBehaviour {
    public float speed = 30;
    public string axis = "Vertical";

    public void FixedUpdate() {
        if (DataPasser.multiplayer) {
            float v = Input.GetAxisRaw(axis);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
        } else {

        }
    }
}
