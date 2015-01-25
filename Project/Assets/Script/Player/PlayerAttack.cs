using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    Collider2D attackArea;

    void Start() {
        attackArea = GameObject.Find("AttackArea").GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update() {
        Vector2 pos = (Vector2)transform.position + rigidbody2D.velocity;
        attackArea.transform.position = pos;

        if (Input.GetButtonDown("Fire1")) {
            if (GameBeat.checkInput()) {    
            }
        }
    }
}
