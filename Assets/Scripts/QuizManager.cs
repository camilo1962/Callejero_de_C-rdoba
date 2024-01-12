using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
#pragma warning disable 649
    //ref to the QuizGameUI script
    [SerializeField] private QuizGameUI quizGameUI;
    //ref to the scriptableobject file
    [SerializeField] private List<QuizDataScriptable> quizDataList;
    [SerializeField] private float timeInSeconds;
    [SerializeField] TextMeshProUGUI _questionText;
    [SerializeField] GameObject respuesta;
    //public GameObject _questionText;
    [SerializeField] String[] miString = new String[7];
    [SerializeField] String[] okString = new String[6];


#pragma warning restore 649

    private string currentCategory = "";
    public int correctAnswerCount = 0;
    
    //questions data
    private List<Question> questions;
    //current question data
    private Question selectedQuetion = new Question();
    private int gameScore;
    private int lifesRemaining;
    private float currentTime;
    private QuizDataScriptable dataScriptable;
    public Text numeroPregunta;

    private GameStatus gameStatus = GameStatus.NEXT;
    
    public GameStatus GameStatus { get { return gameStatus; } }

    public List<QuizDataScriptable> QuizData { get => quizDataList; }

    public void StartGame(int categoryIndex, string category)
    {
        
        currentCategory = category;
        correctAnswerCount = 0;
        gameScore = 0;
        lifesRemaining = 14;
        currentTime = timeInSeconds;
        //set the questions data
        questions = new List<Question>();
        dataScriptable = quizDataList[categoryIndex];
        questions.AddRange(dataScriptable.questions);
        //select the question
        SelectQuestion();
        
        gameStatus = GameStatus.PLAYING;
    }

    /// <summary>
    /// Método utilizado para seleccionar aleatoriamente los datos de las preguntas del formulario de preguntas
    /// </summary>
    private void SelectQuestion()
    {
       
        //obtener el número aleatorio
        int val = UnityEngine.Random.Range(0, questions.Count);
        //establecer el interrogador seleccionado
        selectedQuetion = questions[val];
        //enviar la pregunta a quizGameUI
        quizGameUI.SetQuestion(selectedQuetion);
       
        questions.RemoveAt(val);
       
    }

    private void Update()
    {
        if (gameStatus == GameStatus.PLAYING)
        {
            currentTime -= Time.deltaTime;
            SetTime(currentTime);
            
        }
        numeroPregunta.text = correctAnswerCount.ToString();
    }

    void SetTime(float value)
    {
        TimeSpan time = TimeSpan.FromSeconds(currentTime);       //establecer el valor de tiempo
        quizGameUI.TimerText.text = time.ToString("mm':'ss");   //convertir hora a formato de hora

        if (currentTime <= 0)
        {
            //Game Over
            GameEnd();
        }
    }

    /// <summary>
    /// Método llamado para comprobar si la respuesta es correcta o no
    /// </summary>
    /// <param name="selectedOption">answer string</param>
    /// <returns></returns>
    public bool Answer(string selectedOption)
    {
        //establecer el valor predeterminado en falso
        bool correct = false;
        //si la respuesta seleccionada es similar a la respuesta correcta
        if (selectedQuetion.correctAns == selectedOption)
        {
            //si, la respuesta es correcta
            correctAnswerCount++;
            correct = true;
            gameScore += 1;
            //RespuestaCorrecta.instance.OtroMessage("Ok", 1f);
            for (int i = 0; i < okString.Length; i++)
            {
                int p = UnityEngine.Random.Range(0, okString.Length);
                RespuestaCorrecta.instance.OtroMessage(okString[p] , 1f);

            }
            //_questionText.text = "Correcto ";
            quizGameUI.ScoreText.text = "Has acertado: " + gameScore;
        }
        else
        {
            //No, la respuesta es incorrecta
            //Reducir la vida
            lifesRemaining--;
            quizGameUI.ReduceLife(lifesRemaining);

            for(int n = 0; n < miString.Length; n++)
            {
                int r = UnityEngine.Random.Range(0, miString.Length);
                RespuestaCorrecta.instance.NewMessage(miString[r] + "la respuesta es: "+ "\n\r" + selectedQuetion.correctAns , 2f);
             
            }
           // RespuestaCorrecta.instance.NewMessage( "¡NO!, la respuesta es: " + "\n\r" +  selectedQuetion.correctAns, 2f);
         
            // _questionText.text = "¡  La respuesta correcta es: " +  selectedQuetion.correctAns + " !";


            if (lifesRemaining == 0)
            {
                GameEnd();
            }
          
        }
       
        if (gameStatus == GameStatus.PLAYING)
        {
            if (questions.Count > 0)
            {
                // llame al método SelectQuestion nuevamente después de 1s
                Invoke("SelectQuestion", 1.8f);
            }
            else
            {
                GameEnd();
            }
        }
        //return the value of correct bool
        return correct;
    }

   

    private void GameEnd()
    {
        gameStatus = GameStatus.NEXT;
        quizGameUI.GameOverPanel.SetActive(true);

        //si desea guardar solo el puntaje más alto, luego compare el puntaje actual con el puntaje guardado y, si hay más, guarde el nuevo puntaje
        // por ejemplo: - si correctAnswerCount > PlayerPrefs.GetInt(currentCategory) entonces llama debajo de la línea

        //Guarda los puntos
        PlayerPrefs.SetInt(currentCategory, correctAnswerCount); //guarda los puntos para esta categoría
    }
}

//Estructura de datos para almacenar los datos de las preguntas.
[System.Serializable]
public class Question
{
    public string questionInfo;         //question text
    public QuestionType questionType;   //type
    public Sprite questionImage;        //image for Image Type
    public AudioClip audioClip;         //audio for audio type
    public UnityEngine.Video.VideoClip videoClip;   //video for video type
    public List<string> options;        //options to select
    public string correctAns;           //correct option
}

[System.Serializable]
public enum QuestionType
{
    TEXT,
    IMAGE,
    AUDIO,
    VIDEO
}

[SerializeField]
public enum GameStatus
{
    PLAYING,
    NEXT
}