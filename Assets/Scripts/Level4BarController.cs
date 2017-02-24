using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level4BarController : MonoBehaviour {

    private Image image;
    private Color ImageOriginalcolor;

    // Awake() immediately when the component is initiation
    void Awake() {
        image = GetComponent<Image>();
        ImageOriginalcolor = image.color;
    }

    public void OnMouseEnter() {
        image.color = Color.clear;
    }

    public void OnMouseExit() {
        image.color = ImageOriginalcolor;
    }
}
