using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //incluir la libreria de los textmesh pro

public class LogicaCalidad : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public int calidad;

    void Start()
    {
        calidad = PlayerPrefs.GetInt("numeroDeCalidad", 3);// el PlayerPrefs es para guardar 
        dropdown.value = calidad;
        AjustarCalidad();
    }
    public void AjustarCalidad()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("numeroDeCalidad", dropdown.value);
        calidad = dropdown.value;
    }

}
