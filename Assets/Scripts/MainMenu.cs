using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu :  MonoBehaviour
{
        public void PlayGame (string ir)
        {
            SceneManager.LoadScene(ir);
           
        }
        public void QuitGame ( )
        {
            Application.Quit();
        }
        public void URL(string name)
        {
        Application.OpenURL(name);
        }
   
}
