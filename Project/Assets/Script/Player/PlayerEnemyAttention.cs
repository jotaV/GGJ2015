using UnityEngine;
using System.Collections;

public class PlayerEnemyAttention : MonoBehaviour {

    Collider2D AttetionArea;

    void Start() {
        AttetionArea = GameObject.Find("AttetionArea").GetComponent<Collider2D>();
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Enemy"){
            Enemy enemy = other.GetComponent<Enemy>();

            print("enemy.range " + enemy.range + " : dist " +  Vector3.Distance(other.transform.position, transform.position));

            if(Vector3.Distance(other.transform.position, transform.position) < enemy.range)
                other.GetComponent<Enemy>().moveToContraPlayer = true;
            else
                other.GetComponent<Enemy>().moveToContraPlayer = false;
        }
    }
}
