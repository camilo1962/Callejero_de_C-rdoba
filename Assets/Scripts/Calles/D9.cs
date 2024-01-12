using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class D9 : MonoBehaviour
{

    private void Start()
    {
        var dropdown = transform.GetComponent<TMP_Dropdown>();

        dropdown.options.Clear();

        List<string> items = new List<string>();
        items.Add(" ");
        items.Add("1");
        items.Add("2");
        items.Add("3");
        items.Add("4");
        items.Add("5");
        items.Add("6");
        items.Add("7");
        items.Add("8");
        items.Add("9");

        foreach (var item in items)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData() { text = item });
        }
    }

}