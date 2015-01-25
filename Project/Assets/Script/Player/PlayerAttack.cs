using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAttack : MonoBehaviour {

    // Update is called once per frame

    private List<GameObject> enemys = new List<GameObject>();
    public int lastBeat;

    void FixedUpdate() {

        Vector2 pos, vel = (Vector2) transform.parent.rigidbody2D.velocity;

        vel = new Vector2(vel.x, vel.y * 0.8f);
        pos = (Vector2)transform.parent.transform.position + vel.normalized;

        transform.localPosition = vel.normalized;

        if (Input.GetButtonDown("Fire1")) {
            if (GameBeat.checkInput() != null) {
                foreach (GameObject go in enemys) {
                    go.GetComponent<Enemy>().ReceiveDamage();
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
