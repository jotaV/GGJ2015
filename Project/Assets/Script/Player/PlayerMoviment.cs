using UnityEngine;
using System.Collections;

public class PlayerMoviment : MonoBehaviour {

    public float speed = 10;

    private Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate() {
        Vector2 /*moveVector*/ mv = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
        );

        if(mv.x + mv.y > 1.2f) mv.Normalize();

        rigidbody2D.velocity = mv * speed;
    }

    void Update() {
        Vector2 /*moveVector*/ mv = rigidbody2D.velocity.normalized;

        anim.SetBool("MainEixo", Mathf.Abs(mv.x) > Mathf.Abs(mv.y));
        anim.SetFloat("Horizontal", mv.x);
        anim.SetFloat("Vertical", mv.y);

        if (mv.x < -0.1f) transform.localScale = new Vector3(-1, 1, 1);
        else transform.localScale = new Vector3(1, 1, 1);
    }
}
