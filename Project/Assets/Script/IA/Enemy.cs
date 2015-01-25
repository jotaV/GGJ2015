using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    internal GameObject player;
    internal bool onContactPlayer;
    internal bool lastBeat = false;
    internal bool getDamage = false;

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

    void FixedUpdate() {
        GiveDamage();
    }

    virtual internal void GiveDamage() {
        PlayerAttack pA = GameObject.FindWithTag("PlayerAtack").GetComponent<PlayerAttack>();
        if (pA.lastBeat < GameBeat.beat) return;

        if (onContactPlayer && lastBeat != GameBeat.getBinary() && !getDamage) {
            //print("give Damage " + GameBeat.beat);
        }

        getDamage = false;
        lastBeat = GameBeat.getBinary();
    }

    public void MoveToEnemy() {
        if (Vector3.Distance(transform.position, player.transform.position) > 0.8f) {
            Vector2 /*moveVector*/ mv = (Vector2) player.transform.position - (Vector2)transform.position;
            rigidbody2D.velocity = mv.normalized * speed;
        }
    }

    public void ReceiveDamage() {
        if (!getDamage) {
            getDamage = true;
            //print("Damage Taiken " + GameBeat.beat + " " + GameBeat.lastCalc);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag != "Player") return;

        onContactPlayer = true;
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag != "Player") return;

        onContactPlayer = false;
    }
}
