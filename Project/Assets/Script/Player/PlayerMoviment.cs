using UnityEngine;
using System.Collections;

public class PlayerMoviment : MonoBehaviour {

    public float speed = 10;
 
    void FixedUpdate() {
        Vector2 /*moveVector*/ mv = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
        );

        if(mv.x + mv.y > 1.2f) mv.Normalize();

        rigidbody2D.velocity = mv * speed;
    }
}
