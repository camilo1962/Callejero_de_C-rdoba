using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dropdown1 : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public TMP_Text color;
    private AudioSource sonidos;
    public AudioClip acierto;
    public AudioClip error;


    void Start()
    {
        sonidos = GetComponent<AudioSource>();
    }

    public void Contar()
    {
        if (dropdown.value == 1)
        {

            color.color = Color.black;
            sonidos.PlayOneShot(acierto, 1.0f);
            ScoreManager.instance.AddAciertos();

        }
        else
        {
            color.color = Color.red;
            sonidos.PlayOneShot(error, 1.0f);
            ScoreManager.instance.AddErrores();
        }

    }



}
