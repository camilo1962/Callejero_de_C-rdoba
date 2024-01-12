using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderScripts : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;
    [SerializeField]
    private TMP_Text _sliderText;
    void Start()
    {
        _slider.onValueChanged.AddListener((v) => {
            _sliderText.text = v.ToString();
        });
    }

    
}
