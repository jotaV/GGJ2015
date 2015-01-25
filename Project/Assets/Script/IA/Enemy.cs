using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    internal GameObject player;

    public bool moveToContraPlayer { get; set; }
    public float speed;
    public float range;
   
    void Start() {
        player = GameObject.FindWithTag("Player");
        OnStart();
    }

    virtual internal void OnStart() {}

    void Update() {
        if(moveToContraPlayer) MoveToEnemy();
    }

    public void MoveToEnemy() {
        if (Vector3.Distance(transform.position, player.transform.position) > 0.8f) {
            Vector2 /*moveVector*/ mv = (Vector2) player.transform.position - (Vector2)transform.position;
            rigidbody2D.velocity = mv.normalized * speed;
        }
    }
}
