using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RespuestaCorrecta : MonoBehaviour
{
    public static RespuestaCorrecta instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject mensajePrefab;
    public GameObject mensajeImagePrefab;

    public void NewMessage(string mensage, float tiempo)
    {
        var newMen = Instantiate(mensajePrefab, transform);
        newMen.GetComponent<Mensage>().InitMessage(mensage, tiempo);
    }
    public void OtroMessage(string otromensage, float tiempo)
    {
        var otroMen = Instantiate(mensajeImagePrefab, transform);
        otroMen.GetComponent<Mensage>().OtroMessage(otromensage, tiempo);
    }
}
