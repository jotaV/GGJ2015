using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAttack : MonoBehaviour {

    // Update is called once per frame

    private List<GameObject> enemys = new List<GameObject>();
    public int lastBeat;

    public int life = 5;

    void FixedUpdate() {

        Vector2 pos, vel = (Vector2) transform.parent.rigidbody2D.velocity;

        vel = new Vector2(vel.x, vel.y * 0.8f);
        pos = (Vector2)transform.parent.transform.position + vel.normalized;

        transform.localPosition = vel.normalized;

        if (Input.GetButtonDown("Fire1")) {
            GameBeat.Beat b = GameBeat.checkInput();

            if (b != null) {

                if (enemys.Count != 0) GameBeat.PlayHit();
                foreach (GameObject go in enemys) {
                    GiveDamage(go);
                }

            } else {

                lastBeat = GameBeat.beat;
            
            }
        } else {
            if (GameBeat.checkInput() == null) lastBeat = GameBeat.beat;
        }
    }

    public int CurrentBeatAttack() {
        return lastBeat;
    }

    public void GiveDamage(GameObject enemy) {
        print("Done!");

        Vector2 dir = (Vector2)transform.position - (Vector2)transform.position;
        dir.Normalize();

        if (enemy.GetComponent<Enemy>().ReceiveDamage()) {
            try {
                enemys.Remove(enemy);
            } catch (System.Exception){} 
            Destroy(enemy);
        }

        enemy.rigidbody2D.AddForce(dir * 100);
        transform.parent.rigidbody2D.AddForce(dir * 5);
    }

    int damageBeat = -1;
    public void TakeDamage(GameObject enemy, int beat) {
        if (transform.parent.GetComponent<SpriteSpark>().enabled) return;

        transform.parent.GetComponent<SpriteSpark>().enabled = true;
        life -= 1;

        if (life <= 0) print("Game Oever");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag != "Enemy") return;

        if (!enemys.Contains(other.gameObject))
            enemys.Add(other.gameObject);
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.tag != "Enemy") return;

        if (enemys.Contains(other.gameObject))
            enemys.Remove(other.gameObject);
    }
}
