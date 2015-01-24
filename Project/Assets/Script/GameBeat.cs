using UnityEngine;
using System.Collections;

using System.Linq;

public class GameBeat : MonoBehaviour {

    public static double time, bps, bpm = 150.0f;
    public static int beat;

    void Awake() {
        beat = -1;
        bps = 60.0f / bpm;
    }

    void FixedUpdate() {
        if (beat == -1) { 
            GetComponent<AudioSource>().time = 0;
            GetComponent<AudioSource>().Play();
        }

        time += Time.fixedDeltaTime;

        if (time > bps) { 
            time -= bps;
            if (beat == 7) GetComponent<AudioSource>().time = 0;

            beat = (beat + 1) % 8;
        }

        if (Input.GetButtonDown("Fire1")) print((checkInput() ? "HIT!!!" : "MISS!!") + " " + time);
    }

    static bool getBinary() {
        return beat % 2 == 0;
    }

    static bool checkInput() {
        return time > bps * 0.8f || time < bps * 0.2f;
    }

    void OnGUI() {
        GUI.HorizontalSlider(new Rect(25, 25, 300, 200), beat, 0, 7);
    }
}
