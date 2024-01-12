using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirFeed : MonoBehaviour
{
    
    void Start()
    {
        //Destroy(this.gameObject, 0.5f);
    }

    
    void Update()
    {
          Destroy(this.gameObject, 0.6f);
    }
    private void Awake()
    {
        //Destroy(this.gameObject, 0.6f);
    }
}
