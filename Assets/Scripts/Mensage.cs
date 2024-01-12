using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mensage : MonoBehaviour
{
    public void InitMessage(string message, float time)
    {
        GetComponentInChildren<TMP_Text>().text = message;
        Invoke("DestroySelf", time);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
    public void OtroMessage(string otromessage, float time)
    {
        GetComponentInChildren<TMP_Text>().text = otromessage;
        Invoke("DestroySelf1", time);
    }

    public void DestroySelf1()
    {
        Destroy(gameObject);
    }
}
