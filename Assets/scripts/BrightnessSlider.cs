using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessSlider : MonoBehaviour {

    public Slider brightSlider;
    float bri;

    // Use this for initialization
    void Start()
    {
        brightSlider.value = 0.5f;

    }

    // Update is called once per frame
    public void OnValueChanged()
    {
        bri = brightSlider.value;
        RenderSettings.ambientLight = new Color(bri, bri, bri, 1);
    }
}
