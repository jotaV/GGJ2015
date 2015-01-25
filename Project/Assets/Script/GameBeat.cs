using UnityEngine;
using System.Collections;

using System.Linq;

public class GameBeat : MonoBehaviour {

    public class Beat {
        public int beat;
        public double time;

        public Beat(int beat, double time){
            this.beat = beat;
            this.time = time;
        }
    }

    private static double bps, bpm = 150.0f;

    public static double lastCalc;
    public static int beat;

    void Awake() {
        beat = -1;
        bps = 60.0f / bpm;

        print(bps);

        lastCalc = bps + 1;
    }

    void FixedUpdate() {
        if (beat == -1) { 
            GetComponent<AudioSource>().time = 0;
            GetComponent<AudioSource>().Play();
        }

        double calc = Time.fixedTime % bps;
        if (calc < lastCalc) {
            if (beat == 7) GetComponent<AudioSource>().time = 0;
            beat = (beat + 1) % 8;
        }
        
        lastCalc = calc;

        //if (Input.GetButtonDown("Fire1")) print((checkInput() ? "HIT!!!" : "MISS!!") + " " + lastCalc);
    }

    public static bool getBinary() {
        return beat % 2 == 0;
    }

    public static Beat checkInput() {
        if (lastCalc > bps * 0.75f){
            return new Beat(beat + 1, lastCalc);
        }else if(lastCalc < bps * 0.35f) {
            return new Beat(beat, lastCalc);
        }
        return null;
    }

    void OnGUI() {
        GUI.HorizontalSlider(new Rect(25, 25, 300, 200), beat, 0, 7);
    }
}
