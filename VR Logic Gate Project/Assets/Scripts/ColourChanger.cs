using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChanger : MonoBehaviour
{

    public LogicComponent input;

    void Update()
    {
        if(!input.output) gameObject.GetComponent<Renderer>().material.color = Color.white;
        if(input.output) gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }
}
