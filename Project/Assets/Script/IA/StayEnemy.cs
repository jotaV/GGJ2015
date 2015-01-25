using UnityEngine;
using System.Collections;

public class StayEnemy : Enemy {

    private float waitTime, actionTime;

    internal float wait = 0;

    public float startWaitTime, endWaitTime, startActionTime, entActionTime;
    
    void Update() {
        wait -= Time.deltaTime;

        if (moveToContraPlayer && wait <= 0) {
            MoveToEnemy();
            if (wait <= -actionTime) {
                wait = waitTime;
                OnFinishedCicle();
            }
        }

        //GiveDamage();
    }

    void OnFinishedCicle() {
        waitTime = Random.Range(startWaitTime, endWaitTime);
        actionTime = Random.Range(startActionTime, entActionTime);
    }
}
