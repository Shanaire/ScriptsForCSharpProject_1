using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CounterScript : MonoBehaviour
{
    // Key for the appended names of the different values > BR = Boardroom, CR = Cabaret, CL = Classroom, TR = Theatre, US = Ushape, T = Table, CPT = Chairs Per Table, C = Chairs, 
    public static int CounterVal_T = 0;
    public static int CounterVal_C = 0;

    Text Counter;


    // Use this for initialization
    void Start()
    {
        Counter = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Counter.text = "NUMBER OF TABLES" + Environment.NewLine +
                            ": " + CounterVal_T + Environment.NewLine + Environment.NewLine +


                        "NUMBER OF CHAIRS" + Environment.NewLine +
                            ": " + CounterVal_C;

        Counter.fontSize = (30);
    }
}
