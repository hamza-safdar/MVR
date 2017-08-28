using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MusicSlider : MonoBehaviour
{

    public Slider volumeSlider;

    public void Start()
    {
        volumeSlider.value = 0f;
    }

    // Use this for initialization
    public void OnValueChanged()
    {
        AudioListener.volume = volumeSlider.value;
    }

    void Update()
    {
        
    }

}
