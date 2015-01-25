using UnityEngine;
using System.Collections;

public class SpriteSpark : MonoBehaviour {

    public float duration, lenght;
    private SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
            Destroy(this);
    }

    void Update() {
        Color c;
        if (duration < 0) {
            c = spriteRenderer.color;
            c.a = 1;
            spriteRenderer.color = c;
            
            enabled = false;
        }
        
        duration -= Time.deltaTime;

        float a = 1 - Mathf.PingPong(duration, lenght) / lenght;
        c = spriteRenderer.color;

        c.a = a;
        spriteRenderer.color = c;
    }
}
