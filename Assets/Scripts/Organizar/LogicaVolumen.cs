using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//comandos canvas

public class LogicaVolumen : MonoBehaviour
{

    public Slider Slider;
    public float sliderVolue;
    public Image imageMute;

    void Start()
    {
        sliderVolue = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = sliderVolue;
        RevisarSiEstoyMute();
    }
    public void ChangeSlider(float valor)
    {
        sliderVolue = valor;
        PlayerPrefs.GetFloat("volumenAudio", sliderVolue);
        AudioListener.volume = sliderVolue;
        RevisarSiEstoyMute();
    }
    public void RevisarSiEstoyMute()
    {
        if (sliderVolue == 0)
        {
            imageMute.enabled = true;

        }else
        {
            imageMute.enabled = false;
        }
    }
   
}
