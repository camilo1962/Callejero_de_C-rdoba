using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class CategoryBtnScript : MonoBehaviour
{
  
    public GameObject botonNivel;

    [SerializeField] private Text categoryTitleText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Button btn;
   
    
    
  

    public Button Btn { get => btn; }
    //private void Start()
    //{
    //    candado = GetComponent<Image>();
    //}

    public void SetButton(string title,int totalQuestion)
    {
       
        categoryTitleText.text = title;
     
        scoreText.text = PlayerPrefs.GetInt(title, 0) + "/" + totalQuestion; //obtenemos la puntuación guardada para esta categoría
        if (PlayerPrefs.GetInt(title, 0) > 26)
        {
            botonNivel.GetComponent<Text>().color = Color.blue;
        }
        if (PlayerPrefs.GetInt(title, 0) == 40)
        {
            scoreText.text = "<b><color=#0000FF>CLAVAO</color></b>";
        }
        if (PlayerPrefs.GetInt(title, 0) < 40 && PlayerPrefs.GetInt(title, 0) > 35)
        {
            scoreText.text = "<b><color=#008000>90%</color></b>";
        }
        if (PlayerPrefs.GetInt(title, 0) < 36 && PlayerPrefs.GetInt(title, 0) > 31)
        {
            scoreText.text = "<b><color=#038D25>80%</color></b>";
        }
        if (PlayerPrefs.GetInt(title, 0) < 32 && PlayerPrefs.GetInt(title, 0) > 28)
        {
            scoreText.text = "<b><color=#008000>70%</color></b>";
        }
        if (PlayerPrefs.GetInt(title, 0) > 25 && PlayerPrefs.GetInt(title, 0) < 29)
        {
            scoreText.text = "<b><color=#808080>¡Casi!</color></b>";
        }
        if (PlayerPrefs.GetInt(title, 0) > 0 && PlayerPrefs.GetInt(title, 0) < 26)
        {
            scoreText.text = "<b><color=#FF0000>palmao</color></b>";
        }
    }
    

}
