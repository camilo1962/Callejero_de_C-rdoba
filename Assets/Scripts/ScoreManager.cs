using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;



    [SerializeField] int numeroNivel;

    public TMP_Text scoreAciertos;
    public TMP_Text scoreErrores;
    public TMP_Text porcentaje;
    [SerializeField]
    TMP_Text recordTexto;
    [SerializeField]
    GameObject panelClavao;


    public int aciertos, record = 0;
    public int errores = 0;
    public int alternativas;
    [SerializeField]
    Slider barrapuntos;
   


    private void Awake()
    {
        instance = this;
        if (PlayerPrefs.HasKey("Record" + numeroNivel))
        {
            record = PlayerPrefs.GetInt("Record" + numeroNivel);
            recordTexto.text = record.ToString();
        }

    }

    void Start()
    {
        
        scoreAciertos.text = aciertos.ToString();
        scoreErrores.text = errores.ToString();
        panelClavao.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        barrapuntos.value = aciertos - errores;
        porcentaje.text = (((aciertos - errores) * 100) / (alternativas)).ToString();
        if (((aciertos - errores) * 100 / alternativas) == 100)
        {
            panelClavao.SetActive(true);
           
        }
    }

    public void AddAciertos()
    {
        aciertos += 1;
        
        scoreAciertos.text = aciertos.ToString();
        UpdateRecord();
    }
    public void AddErrores()
    {
        errores += 1;
        scoreErrores.text = errores.ToString();       
    }
    public void UpdateRecord()
    {
        if (aciertos > record)
        {
            record = aciertos;

            recordTexto.text = record.ToString();
            PlayerPrefs.SetInt("Record" + numeroNivel, record);
        }

    }
    public void BorrarLosRecord()
    {
        PlayerPrefs.DeleteKey("Record" + numeroNivel);
        record = 0;
        recordTexto.text = record.ToString();
    }


}
