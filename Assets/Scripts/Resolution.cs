using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resolution : MonoBehaviour
{
    public Text resolutionText;

    private int width;
    private int height;
    public bool fullScreen;

    private int newResolution;

    public void NextResolution()
    {
        newResolution++;
        Resolutions();
    }
    public void BackResolution()
    {
        newResolution--;
        Resolutions();
    }
    public void FullScreen()
    {
        fullScreen = !fullScreen;
    }

    public void Aplicar()
    {
        Screen.SetResolution(width, height, fullScreen);
    }

    private void Resolutions()
    {
        newResolution = Mathf.Clamp(newResolution, 0, 3);
        switch (newResolution)
        {
            case 0://1024 × 576         Notebook
                width = 1024;
                height = 576;
                break;
            case 1://1280 × 720         HD
                width = 1280;
                height = 720;
                break;
            case 2://1366 × 768         TV 32"
                width = 1366;
                height = 768;
                break;
            case 3://1920 × 1080        Monitor 1080p
                width = 1920;
                height = 1080;
                break;
        }
        resolutionText.text = width.ToString() + " - " + height.ToString(); 

    }
}
