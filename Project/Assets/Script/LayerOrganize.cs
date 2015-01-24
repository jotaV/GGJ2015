using UnityEngine;
using System.Collections;

public class LayerOrganize : MonoBehaviour {

    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null) {
            Debug.LogWarning("GameObject " + gameObject + "don't have SpriteRenderer");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update() {
        spriteRenderer.sortingOrder = (int) transform.position.y;
    }
}
