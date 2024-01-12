using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoEntreE : MonoBehaviour
{
    AudioSource _audioSource;

    public static SonidoEntreE instance;
   
    public void Awake()
    {
        if(SonidoEntreE.instance == null)
        {
            SonidoEntreE.instance = this;
            DontDestroyOnLoad(gameObject);
            _audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }


        
    }

    public static void Pausar()
    {
        instance._audioSource.Pause();
    }
    public static void Despausar()
    {
        instance._audioSource.UnPause();
    }
    public void Borrar()
    {
        PlayerPrefs.DeleteAll();
    }


}
